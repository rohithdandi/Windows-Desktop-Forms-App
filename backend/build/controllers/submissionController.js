"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.Delete = exports.Read = exports.Submit = exports.Ping = void 0;
const fs_1 = __importDefault(require("fs"));
const path_1 = __importDefault(require("path"));
const dbPath = path_1.default.join(__dirname, "../db.json");
// @desc    always return true
// @route   POST /api/submission/ping
// @access  Public
const Ping = (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    res.send("true");
});
exports.Ping = Ping;
// @desc    add data to database
// @route   POST /api/submission/Submit
// @access  Public
const Submit = (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const { name, email, phone, link, time } = req.body;
    if (!name || !email || !phone || !link) {
        res.status(400).send("All fields are required");
        return;
    }
    fs_1.default.readFile(dbPath, "utf8", (err, data) => {
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
        fs_1.default.writeFile(dbPath, JSON.stringify(db, null, 2), (err) => {
            if (err) {
                res.status(500).send("Error writing to database");
                return;
            }
            res.status(201).send("Submission successful");
        });
    });
});
exports.Submit = Submit;
// @desc    send submission data
// @route   GET /api/submission/read/:id
// @access  Public
const Read = (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const index = parseInt(req.params.id);
    fs_1.default.readFile(dbPath, "utf8", (err, data) => {
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
            const filteredSubmissions = db.submissions.filter((submission) => !submission.deleted);
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
        }
        catch (error) {
            res.status(500).send("Error parsing database data");
        }
    });
});
exports.Read = Read;
// @desc    delete submission data
// @route   DELETE /api/submission/delete/:id
// @access  Public
const Delete = (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const index = parseInt(req.params.id);
    fs_1.default.readFile(dbPath, "utf8", (err, data) => {
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
            const filteredSubmissions = db.submissions.filter((submission) => !submission.deleted);
            if (index < 0 || index >= filteredSubmissions.length) {
                res.status(404).send("Submission not found");
                return;
            }
            filteredSubmissions[index].deleted = true;
            const originalIndex = db.submissions.findIndex((sub) => sub.email === filteredSubmissions[index].email);
            db.submissions[originalIndex].deleted = true;
            fs_1.default.writeFile(dbPath, JSON.stringify(db, null, 2), (err) => {
                if (err) {
                    res.status(500).send("Error writing to database");
                    return;
                }
                res.status(200).send("Submission successfully deleted");
            });
        }
        catch (error) {
            res.status(500).send("Error parsing database data");
        }
    });
});
exports.Delete = Delete;
