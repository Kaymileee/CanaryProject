import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getVocabularies = createAsyncThunk(
  "voc/getVocabularies",
  async (topicId) => {
    try {
      const res = await axios.get(
        `https://localhost:5000/api/Vocabularies/getVocablariesByTopicId?topicId=${topicId}`
      );
      const { data } = res;
      return data.resultObj;
    } catch (err) {
      console.log(err);
    }
  }
);
