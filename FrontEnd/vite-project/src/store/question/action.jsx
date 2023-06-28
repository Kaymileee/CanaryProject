import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const checkAnswer = createAsyncThunk(
  "question/checkAnswer",
  async (quesId, isCorrect) => {
    try {
      const res = await axios.post(
        `https://localhost:5000/api/Questions/check_answer`,
        {
          questionId: quesId,
          isCorrect: isCorrect,
        }
      );
      console.log(res);
      return res;
    } catch (err) {
      console.log(err);
    }
  }
);
