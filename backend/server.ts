import express, { Application, Request, Response } from "express";
import dotenv from "dotenv";
import cors from "cors";
import submissionRoutes from "./routes/submissionRoutes";

dotenv.config();

const port: number = parseInt(process.env.PORT as string, 10) || 5000;
const app: Application = express();

// Middleware
app.use(cors());
app.use(express.json());
app.use(express.urlencoded({ extended: false }));

// Routes
app.use("/api/submission", submissionRoutes);

// Start server
app.listen(port, () => {
  console.log(`Server started on port ${port}`);
});
