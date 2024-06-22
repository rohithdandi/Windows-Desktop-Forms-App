import express, { Request, Response, Router } from "express";
import {
  Ping,
  Submit,
  Read,
  Delete,
} from "../controllers/submissionController";

const router: Router = express.Router();

router.get("/ping", Ping);
router.post("/submit", Submit);
router.get("/read/:id", Read);
router.delete("/delete/:id", Delete);

export default router;
