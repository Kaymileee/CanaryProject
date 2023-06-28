import axios from "axios";
import { useEffect, useState } from "react";
import { createPortal } from "react-dom";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, useParams, useSearchParams } from "react-router-dom";
import { updatePoint } from "../store/user/action";

const ExamPage = () => {
  const { topicId } = useParams();
  const [questions, setQuestions] = useState();
  const [listAnswer, setListAnswer] = useState({
    item1: "",
    item2: "",
    item3: "",
    item4: "",
    item5: "",
  });
  const [check, setCheck] = useState(false);
  const [score, setScore] = useState(0);
  const navigate = useNavigate();
  const { updateInfo, setUpdateInfo } = useState({
    userId: "",
    point: score,
  });
  const handleChoice = (e, n) => {
    switch (n) {
      case 0:
        setListAnswer({ ...listAnswer, item1: Number(e.target.dataset.value) });

        break;
      case 1:
        setListAnswer({ ...listAnswer, item2: Number(e.target.dataset.value) });

        break;
      case 2:
        setListAnswer({ ...listAnswer, item3: Number(e.target.dataset.value) });

        break;
      case 3:
        setListAnswer({ ...listAnswer, item4: Number(e.target.dataset.value) });

        break;
      case 4:
        setListAnswer({ ...listAnswer, item5: Number(e.target.dataset.value) });

        break;

      default:
        break;
    }
  };
  const userInfo = useSelector((state) => state.user.data.userId);

  useEffect(() => {
    const fetchQuestions = async () => {
      const res = await axios.get(
        `https://localhost:5000/api/Questions/getByTopicId?tpId=${topicId}`
      );
      const data = await res.data.resultObj;
      console.log(data);
      setQuestions(data);
      setUpdateInfo({ ...updateInfo, userId: userInfo });
    };
    fetchQuestions();
  }, []);
  const dispatch = useDispatch();
  const handleCheck = () => {
    setCheck(true);
    const answerUser = Object.values(listAnswer);
    const total = questions.map((item) => item.isCorrect);
    if (answerUser != null) {
      // push Item from De1 state to arr
      const arrRest = total.filter((item, index) => item !== total[index]);
      // console.log(100 - (arrRest.length / answersIdOne.length) * 100);
      setScore(100 - (arrRest.length / answerUser.length) * 100);
    } else {
      setScore(0);
    }
  };
  return (
    <>
      <div className="flex flex-wrap items-center justify-around gap-5">
        {questions?.length > 0 &&
          questions.map((question, ind) => (
            <div className="p-5 border" key={ind}>
              <h4 className="p-2 text-xl font-bold text-center">
                Question {ind + 1}: {question.questionString} ?
              </h4>
              <img src={question.quesURL} alt="" />
              <div className="flex items-center justify-between">
                <div
                  className="px-4 py-2 border rounded-md cursor-pointer ans"
                  data-value="0"
                  onClick={(e) => handleChoice(e, ind)}
                >
                  {question.answer_1}
                </div>
                <div
                  className="px-4 py-2 border rounded-md cursor-pointer ans"
                  data-value="1"
                  onClick={(e) => handleChoice(e, ind)}
                >
                  {question.answer_2}
                </div>
                <div
                  className="px-4 py-2 border rounded-md cursor-pointer ans"
                  data-value="2"
                  onClick={(e) => handleChoice(e, ind)}
                >
                  {question.answer_3}
                </div>
                <div
                  className="px-4 py-2 border rounded-md cursor-pointer ans"
                  data-value="3"
                  onClick={(e) => handleChoice(e, ind)}
                >
                  {question.answer_4}
                </div>
              </div>
            </div>
          ))}
      </div>
      <button
        className="px-4 py-2 my-10 text-white bg-green-500 rounded-lg"
        onClick={handleCheck}
      >
        Hoàn thành{" "}
      </button>
      {check &&
        createPortal(
          <div className="fixed w-[500px]  top-2/4 left-2/4 rounded-lg  bg-green-500 text-white -translate-x-2/4 -translate-y-2/4 flex items-center flex-col p-10 gap-y-2">
            <h2 className="text-3xl font-bold text-center">🎊</h2>
            <h2 className="text-3xl font-bold text-center ">Congratulations</h2>
            <h4 className="text-center">
              Your score : <span className="font-bold">{score}</span>
            </h4>
            <div
              className="px-4 py-2 text-white bg-green-600 border rounded-lg cursor-pointer"
              onClick={() => {
                navigate("/Topics");
              }}
            >
              Next
            </div>
          </div>,
          document.body
        )}
    </>
  );
};

export default ExamPage;
