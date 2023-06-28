import { createSlice } from "@reduxjs/toolkit";
import { getVocabularies } from "./action";
const initialState = {
  data: [],
  status: "idle",
};
export const vocSlice = createSlice({
  name: "vocabularies",
  initialState,
  extraReducers: (builder) => {
    builder
      .addCase(getVocabularies.pending, (state) => {
        state.status = "loading";
      })
      .addCase(getVocabularies.fulfilled, (state, action) => {
        (state.status = "idle"), (state.data = action.payload);
      });
  },
});
export default vocSlice.reducer;
