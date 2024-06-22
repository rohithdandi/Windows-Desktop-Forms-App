"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const dotenv_1 = __importDefault(require("dotenv"));
const cors_1 = __importDefault(require("cors"));
const submissionRoutes_1 = __importDefault(require("./routes/submissionRoutes"));
dotenv_1.default.config();
const port = parseInt(process.env.PORT, 10) || 5000;
const app = (0, express_1.default)();
// Middleware
app.use((0, cors_1.default)());
app.use(express_1.default.json());
app.use(express_1.default.urlencoded({ extended: false }));
// Routes
app.use("/api/submission", submissionRoutes_1.default);
// Start server
app.listen(port, () => {
    console.log(`Server started on port ${port}`);
});
