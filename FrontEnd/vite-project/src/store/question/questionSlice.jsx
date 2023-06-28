import { createSlice } from "@reduxjs/toolkit";
import { checkAnswer } from "./action";
const initialState = {
  data: [],
  status: "idle",
};
export const vocSlice = createSlice({
  name: "questions",
  initialState,
  extraReducers: (builder) => {
    builder
      .addCase(checkAnswer.pending, (state) => {
        state.status = "loading";
      })
      .addCase(checkAnswer.fulfilled, (state, action) => {
        (state.status = "idle"), (state.data = action.payload);
      });
  },
});
export default vocSlice.reducer;
