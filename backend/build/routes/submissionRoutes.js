"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const submissionController_1 = require("../controllers/submissionController");
const router = express_1.default.Router();
router.get("/ping", submissionController_1.Ping);
router.post("/submit", submissionController_1.Submit);
router.get("/read/:id", submissionController_1.Read);
router.delete("/delete/:id", submissionController_1.Delete);
exports.default = router;
