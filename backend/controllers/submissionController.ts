import { Request, Response } from "express";
import fs from "fs";
import path from "path";

const dbPath = path.join(__dirname, "../db.json");

// @desc    always return true
// @route   POST /api/submission/ping
// @access  Public
export const Ping = async (req: Request, res: Response): Promise<void> => {
  res.send("true");
};

// @desc    add data to database
// @route   POST /api/submission/Submit
// @access  Public
export const Submit = async (req: Request, res: Response): Promise<void> => {
  const { name, email, phone, link, time } = req.body;

  if (!name || !email || !phone || !link) {
    res.status(400).send("All fields are required");
    return;
  }

  fs.readFile(dbPath, "utf8", (err, data) => {
    if (err) {
      res.status(500).send("Error reading database");
      return;
    }

    const db = JSON.parse(data);
    const newSubmission = {
      deleted: false,
      name,
      email,
      phone,
      link,
      time,
    };

    db.submissions.push(newSubmission);

    fs.writeFile(dbPath, JSON.stringify(db, null, 2), (err) => {
      if (err) {
        res.status(500).send("Error writing to database");
        return;
      }

      res.status(201).send("Submission successful");
    });
  });
};

// @desc    send submission data
// @route   GET /api/submission/read/:id
// @access  Public
export const Read = async (req: Request, res: Response): Promise<void> => {
  const index = parseInt(req.params.id);

  fs.readFile(dbPath, "utf8", (err, data) => {
    if (err) {
      res.status(500).send("Error reading database");
      return;
    }

    try {
      const db = JSON.parse(data);

      if (isNaN(index) || index < 0 || index >= db.submissions.length) {
        res.status(404).send("Invalid index");
        return;
      }

      // Filter submissions where deleted is false
      const filteredSubmissions = db.submissions.filter(
        (submission: { deleted: boolean }) => !submission.deleted
      );

      if (index < 0 || index >= filteredSubmissions.length) {
        res.status(404).send("Submission not found");
        return;
      }

      const results = {
        "index-1": index - 1 >= 0 ? "true" : "false",
        index: filteredSubmissions[index],
        "index+1": index + 1 < filteredSubmissions.length ? "true" : "false",
      };

      res.status(200).json(results);
    } catch (error) {
      res.status(500).send("Error parsing database data");
    }
  });
};

// @desc    delete submission data
// @route   DELETE /api/submission/delete/:id
// @access  Public
export const Delete = async (req: Request, res: Response): Promise<void> => {
  const index = parseInt(req.params.id);

  fs.readFile(dbPath, "utf8", (err, data) => {
    if (err) {
      res.status(500).send("Error reading database");
      return;
    }

    try {
      const db = JSON.parse(data);

      if (isNaN(index) || index < 0 || index >= db.submissions.length) {
        res.status(404).send("Invalid index");
        return;
      }

      // Filter submissions where deleted is false
      const filteredSubmissions = db.submissions.filter(
        (submission: { deleted: boolean }) => !submission.deleted
      );

      if (index < 0 || index >= filteredSubmissions.length) {
        res.status(404).send("Submission not found");
        return;
      }

      filteredSubmissions[index].deleted = true;
      const originalIndex = db.submissions.findIndex(
        (sub: { email: string }) => sub.email === filteredSubmissions[index].email
      );
      db.submissions[originalIndex].deleted = true;

      fs.writeFile(dbPath, JSON.stringify(db, null, 2), (err) => {
        if (err) {
          res.status(500).send("Error writing to database");
          return;
        }
        res.status(200).send("Submission successfully deleted");
      });
    } catch (error) {
      res.status(500).send("Error parsing database data");
    }
  });
};
