import { createSlice } from "@reduxjs/toolkit";
import { loginUser, logout, updatePoint } from "./action";

const initialState = {
  data: [],
  isLoading: false,
  isSuccess: false,
  errorMessage: "",
};

export const userSlice = createSlice({
  name: "user",
  initialState,
  extraReducers: {
    [loginUser.pending]: (state) => {
      state.isLoading = true;
    },
    [loginUser.fulfilled]: (state, { payload }) => {
      state.isLoading = false;
      state.isSuccess = true;
      state.data = payload;
    },
    [loginUser.rejected]: (state, { payload }) => {
      state.isLoading = false;
      state.isSuccess = false;
      state.errorMessage = payload;
    },
    [logout.fulfilled]: (state) => {
      state.isLoggedIn = false;
      state.data = [];
    },
    [updatePoint.fulfilled]: (state, { payload }) => {
      state.isLoading = false;
      state.data = payload;
    },
  },
});

export default userSlice.reducer;
