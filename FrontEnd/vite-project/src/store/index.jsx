import { configureStore } from "@reduxjs/toolkit";
import userReducer from "./user/userSlice";
import vocReducer from "./vocabularies/vocSlice";
import questionReducer from "./question/questionSlice";
export const store = configureStore({
  reducer: {
    user: userReducer,
    vocabularies: vocReducer,
    questions: questionReducer,
  },
});
