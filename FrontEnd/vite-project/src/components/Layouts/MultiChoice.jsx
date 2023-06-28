import { collection, getDocs } from "firebase/firestore";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../context/authContext";
import { db } from "../../firebaseConfig/fbConfig";
import ChoiceItem from "../ItemChoice/ChoiceItem";
import DashBoard from "./DashBoard";
import LoginPage from "./LoginPage";

const MultiChoice = () => {
  const navigate = useNavigate();
  const [next, setNext] = useState(0);
  const { userInfo } = useAuth();
  const [check, setCheck] = useState(true);
  const [listChoice, setListChoice] = useState([]);
  const [score, setScore] = useState(0);
  let solution = [];
  let resultUi = [];
  let arrRest;
  const [openResult, setOpenResult] = useState(false);
  const [error, setError] = useState({
    errorAll: "",
    errorForOne: "",
    errorForTwo: "",
    errorForThree: "",
    errorForFour: "",
    errorForFive: "",
  });
  const [choice, setChoice] = useState({
    ques_1: "",
    ques_2: "",
    ques_3: "",
    ques_4: "",
    ques_5: "",
  });

  useEffect(() => {
    const colRef = collection(db, "kiem tra trac nghiem");

    async function getData() {
      const querySnapshot = await getDocs(colRef);
      let arrQuesChoice = [];
      querySnapshot.forEach((doc) => {
        // console.log(doc.id, " => ", doc.data());
        arrQuesChoice.push(doc.id, doc.data());
      });
      setListChoice(arrQuesChoice);
    }
    getData();
  }, []);
  if (!userInfo) {
    return <LoginPage></LoginPage>;
  }
  let quesI = listChoice.filter((ques) => ques.maLoai === next);
  const arr = quesI.map((item) => {
    solution.push(item.DapAn);
  });
  function KqForUI() {
    quesI.map((item) => {
      // resultUi.push(item.DapAn);
      switch (item.DapAn) {
        case "A":
          resultUi.push(item.A);

          break;
        case "B":
          resultUi.push(item.B);

          break;
        case "C":
          resultUi.push(item.C);

          break;

        default:
          break;
      }
    });
  }
  KqForUI();
  const handleCheckResult = () => {
    if (choice.ques_1 === "") {
      setError({ ...error, errorForOne: "Xin hãy chọn đáp án câu 1" });
    } else {
      setError({ ...error, errorForOne: "" });
    }
    if (choice.ques_2 === "") {
      setError({ ...error, errorForTwo: "Xin hãy chọn đáp án câu 2" });
    } else {
      setError({ ...error, errorForTwo: "" });
    }
    if (choice.ques_3 === "") {
      setError({ ...error, errorForThree: "Xin hãy chọn đáp án câu 3" });
    } else {
      setError({ ...error, errorForThree: "" });
    }
    if (choice.ques_4 === "") {
      setError({ ...error, errorForFour: "Xin hãy chọn đáp án câu 4" });
    } else {
      setError({ ...error, errorForFour: "" });
    }
    if (choice.ques_5 === "") {
      setError({ ...error, errorForFive: "Xin hãy chọn đáp án câu 5" });
    } else {
      setError({ ...error, errorForFive: "" });
    }
    if (
      choice.ques_1 === "" &&
      choice.ques_2 === "" &&
      choice.ques_3 === "" &&
      choice.ques_4 === "" &&
      choice.ques_5 === ""
    ) {
      setError({ ...error, errorAll: "Xin hãy chọn các đáp án" });
    } else {
      setError({ ...error, errorAll: "" });
    }
    const resultForUser = Object.values(choice);
    arrRest = resultForUser.filter((item, index) => item !== solution[index]);
    setScore(100 - (arrRest.length / solution.length) * 100);
  };
  const handleNext = () => {
    setNext(next + 1);
    setScore(0);
    setChoice({
      ques_1: "",
      ques_2: "",
      ques_3: "",
      ques_4: "",
      ques_5: "",
    });
  };
  return (
    <div className="container my-10 border">
      <div className="p-10 bg-white rounded-lg">
        <h3 className="text-2xl font-semibold text-center text-black uppercase">
          Chọn đáp án đúng📝
        </h3>
        {/* data */}
        <div className="grid grid-cols-2 gap-2">
          {quesI &&
            quesI.map((item, index) => (
              <ChoiceItem
                key={index}
                item={item}
                setChoice={setChoice}
                choice={choice}
                index={index}
              ></ChoiceItem>
            ))}
        </div>
        {error.errorForOne && (
          <div className="font-semibold text-red-600">{error.errorForOne}</div>
        )}
        {error.errorForTwo && (
          <div className="font-semibold text-red-600">{error.errorForTwo}</div>
        )}
        {error.errorForThree && (
          <div className="font-semibold text-red-600">
            {error.errorForThree}
          </div>
        )}
        {error.errorForFour && (
          <div className="font-semibold text-red-600">{error.errorForFour}</div>
        )}
        {error.errorForFive && (
          <div className="font-semibold text-red-600">{error.errorForFive}</div>
        )}
        {error.errorAll && (
          <div className="font-semibold text-red-600">{error.errorAll}</div>
        )}
        {/* Result */}

        <div className=" w-[500px]  text-slate-900 text-left">
          <h5
            className="font-semibold cursor-pointer"
            onClick={() => setOpenResult(!openResult)}
          >
            Xem Kết quả:
          </h5>
          {openResult &&
            resultUi &&
            resultUi.map((item, index) => (
              <div key={index} className="flex items-center gap-x-2">
                <span className="font-medium">{`Câu ${index + 1} : `}</span>
                <span>{item}</span>
              </div>
            ))}
        </div>

        {/* score */}
        {score >= 0 && (
          <h3 className="mt-10 font-semibold text-blue-400">
            Score: <span className="text-blue-700">{score}/100</span>
          </h3>
        )}
        <div className="flex items-center justify-center gap-x-5">
          <button
            className={
              "bg-gradient-secondary my-10 inline-block px-6 py-3 text-sm font-medium text-white rounded-lg  text-opacity-1"
            }
            onClick={handleCheckResult}
          >
            Kết quả
          </button>
          {score === 100 ? (
            <button
              className="px-6 py-3 my-10 rounded-lg bg-primary animate-pulse"
              onClick={handleNext}
            >
              Tiếp tục
            </button>
          ) : null}
        </div>
      </div>
    </div>
  );
};

export default MultiChoice;
