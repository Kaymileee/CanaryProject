import React from "react";
import { useAuth } from "../../context/authContext";
import DashBoard from "./DashBoard";
import LoginPage from "./LoginPage";

const ExercisePage = () => {
  const { userInfo } = useAuth();
  if (!userInfo) {
    return <LoginPage></LoginPage>;
  }
  return (
    <>
      <DashBoard></DashBoard>
    </>
  );
};

export default ExercisePage;
