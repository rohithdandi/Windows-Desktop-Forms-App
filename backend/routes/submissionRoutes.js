const express = require("express");
const router = express.Router();
const {
  Ping,
  Submit,
  Read,
  Delete,
} = require("../controllers/submissionController");

router.get("/ping", Ping);
router.post("/submit", Submit);
router.get("/read/:id", Read);
router.delete("/delete/:id", Delete);

module.exports = router;
