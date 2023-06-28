import { Route, Routes } from "react-router-dom";
import "./App.css";
import LoginPage from "./components/Layouts/LoginPage";
import StartPage from "./components/Layouts/StartPage";
import HeaderTitle from "./components/title/HeaderTitle";
import TopicsPage from "./pages/TopicsPage";
import TopicDesc from "./pages/TopicDesc";
import SignUpPage from "./components/Layouts/SignUpPage";
import UserInfoPage from "./pages/UserInfoPage";
import AI from "./components/Layouts/AI";
import ExamPage from "./pages/ExamPage";
// import AI from "./components/Layouts/AI";
function App() {
  return (
    <Routes>
      <Route element={<StartPage></StartPage>}>
        <Route path="/" element={<HeaderTitle></HeaderTitle>}></Route>
        <Route path="/sign-in" element={<LoginPage></LoginPage>}></Route>
        <Route path="/sign-up" element={<SignUpPage></SignUpPage>}></Route>

        <Route path="/Topics" element={<TopicsPage></TopicsPage>}></Route>

        <Route
          path="/Topics/:topicId"
          element={<TopicDesc></TopicDesc>}
        ></Route>
        <Route path="/Exam/:topicId" element={<ExamPage></ExamPage>}></Route>
        <Route
          path="/user/info"
          element={<UserInfoPage></UserInfoPage>}
        ></Route>
        <Route path="/AI" element={<AI></AI>}></Route>
        {/* <Route path="/dashboard" element={<DashBoard></DashBoard>}></Route> */}
      </Route>
      <Route></Route>
    </Routes>
  );
}

export default App;
