const fs = require("fs");
const path = require("path");
const dbPath = path.join(__dirname, "../db.json");

// @desc    always return true
// @route   POST /api/submission/ping
// @access  Public
const Ping = async (req, res) => {
  res.send("true");
};

// @desc    add data to database
// @route   POST /api/submission/Submit
// @access  Public
const Submit = async (req, res) => {
  const { name, email, phone, link, time } = req.body;

  if (!name || !email || !phone || !link) {
    return res.status(400).send("All fields are required");
  }

  fs.readFile(dbPath, "utf8", (err, data) => {
    if (err) {
      return res.status(500).send("Error reading database");
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
        return res.status(500).send("Error writing to database");
      }

      res.status(201).send("Submission succesful");
    });
  });
};

// @desc    send submission data
// @route   GET /api/submission/read/:id
// @access  Public
const Read = async (req, res) => {
  const index = parseInt(req.params.id);

  fs.readFile(dbPath, "utf8", (err, data) => {
    if (err) {
      return res.status(500).send("Error reading database");
    }

    try {
      const db = JSON.parse(data);

      if (isNaN(index) || index < 0 || index >= db.submissions.length) {
        return res.status(404).send("Invalid index");
      }

      // Filter submissions where deleted is false
      const filteredSubmissions = db.submissions.filter(
        (submission) => !submission.deleted
      );

      if (index < 0 || index >= filteredSubmissions.length) {
        return res.status(404).send("Submission not found");
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

const Delete = async (req, res) => {
  const index = parseInt(req.params.id);

  fs.readFile(dbPath, "utf8", (err, data) => {
    if (err) {
      return res.status(500).send("Error reading database");
    }

    try {
      const db = JSON.parse(data);

      if (isNaN(index) || index < 0 || index >= db.submissions.length) {
        return res.status(404).send("Invalid index");
      }

      // Filter submissions where deleted is false
      const filteredSubmissions = db.submissions.filter(
        (submission) => !submission.deleted
      );

      if (index < 0 || index >= filteredSubmissions.length) {
        return res.status(404).send("Submission not found");
      }

      filteredSubmissions[index].deleted = true;
      const originalIndex = db.submissions.findIndex(
        (sub) => sub.email === filteredSubmissions[index].email
      );
      db.submissions[originalIndex].deleted = true;
      //console.log(db.submissions[originalIndex].deleted);
      fs.writeFile(dbPath, JSON.stringify(db, null, 2), (err) => {
        if (err) {
          return res.status(500).send("Error writing to database");
        }
        res.status(200).send("Submission succesfully deleted");
      });
    } catch (error) {
      res.status(500).send("Error parsing database data");
    }
  });
};

module.exports = {
  Ping,
  Submit,
  Read,
  Delete,
};
