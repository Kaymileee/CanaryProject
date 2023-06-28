import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const loginUser = createAsyncThunk(
  "user/loginUser",
  async (user, { rejectWithValue }) => {
    try {
      const { data } = await axios.post(
        `https://localhost:5000/api/Users/login`,
        {
          ...user,
        }
      );
      localStorage.setItem("user", JSON.stringify(data));
      return data;
    } catch (error) {
      return rejectWithValue(error.message);
    }
  }
);
export const logout = createAsyncThunk("auth/logout", async () => {
  localStorage.removeItem("user");
});

export const sendCode = createAsyncThunk("auth/sendCode", async (email) => {
  try {
    const res = await axios.post(
      `https://localhost:5000/api/Users/forgotPassword?email=${email}`
    );
    console.log(res);
    return res.json();
  } catch (err) {
    console.log(err);
  }
});
export const newPassword = createAsyncThunk(
  "auth/newPassword",
  async (data) => {
    try {
      const res = await axios.post(
        `https://localhost:5000/api/Users/resetPassword`,
        data
      );
      console.log(res);
    } catch (err) {
      console.log(err);
    }
  }
);
export const registerUser = createAsyncThunk(
  "auth/registerUser",
  async (newUser) => {
    try {
      const res = await axios.post(
        `https://localhost:5000/api/Users/register`,
        newUser
      );
      return res;
    } catch (err) {
      console.log(err);
    }
  }
);
export const updatePoint = createAsyncThunk(
  "auth/updatePoint",
  async (data) => {
    try {
      const res = await axios.post(
        `https://localhost:5000/api/Users/UpdatePoint`,
        data
      );
      return res;
    } catch (err) {
      console.log(err);
    }
  }
);
