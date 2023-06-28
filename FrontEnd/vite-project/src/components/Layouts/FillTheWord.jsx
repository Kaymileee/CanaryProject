import { collection, getDoc, getDocs, query } from "firebase/firestore";
import React, { useEffect, useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../context/authContext";
import { db } from "../../firebaseConfig/fbConfig";
import DashBoard from "./DashBoard";
import ItemFill from "../FillWord/ItemFill";
import LoginPage from "./LoginPage";
const FillTheWord = () => {
  const [de1, setDe1] = useState({
    ques_1: "",
    ques_2: "",
    ques_3: "",
    ques_4: "",
    ques_5: "",
  });
  const [next, setNext] = useState(0);
  const [score, setScore] = useState(0);
  const demo = ["apple", "orange"];
  const navigate = useNavigate();
  const [listQues, setListQues] = useState([]);
  let answersIdOne = [];
  let answerOne = [];

  const { userInfo } = useAuth();
  // get Questions
  useEffect(() => {
    const colRef = collection(db, "kiem tra dien tu");
    async function getData() {
      const querySnapshot = await getDocs(colRef);
      let arrQues = [];
      querySnapshot.forEach((doc) => {
        // console.log(doc.id, " => ", doc.data());
        arrQues.push(doc.id, doc.data());
      });
      setListQues(arrQues);
    }
    getData();
  }, []);

  useEffect(() => {
    if (!userInfo) {
      navigate("/sign-in");
    }
  }, [userInfo]);
  // get exem ID:one
  let quesIdOne = listQues.filter((ques) => ques.maLoai === next);
  // get Answer ID one
  // eslint-disable-next-line array-callback-return
  let arr = quesIdOne.map((item) => {
    // console.log(item.DapAn);
    answersIdOne.push(item.DapAn.toLowerCase());
  });
  const handleCheck = () => {
    if (
      de1.ques_1 !== "" &&
      de1.ques_2 !== "" &&
      de1.ques_3 !== "" &&
      de1.ques_4 !== "" &&
      de1.ques_5 !== ""
    ) {
      // push Item from De1 state to arr
      const answerUser = Object.values(de1);
      const arrRest = answerUser.filter(
        (item, index) => item !== answersIdOne[index]
      );
      // console.log(100 - (arrRest.length / answersIdOne.length) * 100);
      setScore(100 - (arrRest.length / answersIdOne.length) * 100);
    } else {
      setScore(0);
    }
  };

  const handleNext = () => {
    setNext(next + 1);
    setDe1({
      ques_1: "",
      ques_2: "",
      ques_3: "",
      ques_4: "",
      ques_5: "",
    });

    setScore(0);
  };
  if (!userInfo) {
    return <LoginPage></LoginPage>;
  }
  // const handleRef = (n) => {
  //   switch (n) {
  //     case 0:
  //       return inpRef;
  //       break;
  //     case 1:
  //       return inpRefTwo;
  //       break;
  //     case 2:
  //       return inpRefThree;
  //       break;
  //     case 3:
  //       return inpRefFour;
  //       break;
  //     case 4:
  //       return inpRefFive;
  //       break;

  //     default:
  //       break;
  //   }
  // };
  return (
    <>
      <div className="container flex-col w-full my-20 bg-white border rounded-lg">
        <h3 className="my-5 text-2xl font-semibold text-center text-black uppercase">
          Điền từ thích hợp vào chỗ trống📝
        </h3>
        <div className="grid grid-cols-2 gap-2">
          {quesIdOne.map((item, index) => (
            <ItemFill
              next={next}
              key={index}
              de1={de1}
              setDe1={setDe1}
              index={index}
              item={item}
            ></ItemFill>
          ))}
        </div>
        {/* <div className="flex flex-col items-start mb-5 ques">
            <h4 className="text-black">Ques 1:</h4>
            <div className="flex items-center w-full mb-10 gap-x-5">
              <div className="w-[250px] h-[200px]">
                <img
                  src={quesIdOne[0]?.Hinh}
                  alt=""
                  className="object-cover w-full h-full rounded-lg"
                />
              </div>
              <div className="flex gap-x-1">
                <label htmlFor="ques" className="text-xl text-black">
                  This is a
                </label>
                <input
                  ref={inpRef}
                  type="text"
                  id="ques"
                  className=" outline-none text-xl text-[#ffb86c]"
                  placeholder="..."
                  onChange={(e) =>
                    setDe1({ ...de1, ques_1: e.target.value.toLowerCase() })
                  }
                />
              </div>
            </div>
          </div> */}

        {/* <div className="flex flex-col items-start mb-5 ques">
            <h4 className="text-black">Ques 2:</h4>
            <div className="flex items-center w-full mb-10 gap-x-5">
              <div className="w-[250px] h-[200px] ">
                <img
                  src={quesIdOne[1]?.Hinh}
                  alt=""
                  className="object-cover w-full h-full rounded-lg"
                />
              </div>
              <div className="flex gap-x-1">
                <label htmlFor="ques" className="text-xl text-black">
                  This is a
                </label>
                <input
                  type="text"
                  ref={inpRefTwo}
                  id="ques"
                  className=" outline-none text-xl text-[#ffb86c]"
                  placeholder="..."
                  onChange={(e) =>
                    setDe1({ ...de1, ques_2: e.target.value.toLowerCase() })
                  }
                />
              </div>
            </div>
          </div>
          <div className="flex flex-col items-start mb-5 ques">
            <h4 className="text-black">Ques 3:</h4>
            <div className="flex items-center w-full mb-10 gap-x-5">
              <div className="w-[100px] h-[100px] ">
                <img
                  src={quesIdOne[2]?.Hinh}
                  alt=""
                  className="object-cover w-full h-full rounded-lg"
                />
              </div>
              <div className="flex gap-x-1">
                <label htmlFor="ques" className="text-xl text-black">
                  This is a
                </label>
                <input
                  type="text"
                  ref={inpRefThree}
                  id="ques"
                  className=" outline-none text-xl text-[#ffb86c]"
                  placeholder="..."
                  onChange={(e) =>
                    setDe1({ ...de1, ques_3: e.target.value.toLowerCase() })
                  }
                />
              </div>
            </div>
          </div>
          <div className="flex flex-col items-start mb-5 ques">
            <h4 className="text-black">Ques 4:</h4>
            <div className="flex items-center w-full mb-10 gap-x-5">
              <div className="w-[100px] h-[100px] ">
                <img
                  src={quesIdOne[3]?.Hinh}
                  alt=""
                  className="object-cover w-full h-full rounded-lg"
                />
              </div>
              <div className="flex gap-x-1">
                <label htmlFor="ques" className="text-xl text-black">
                  This is a
                </label>
                <input
                  type="text"
                  ref={inpRefFour}
                  id="ques"
                  className=" outline-none text-xl text-[#ffb86c]"
                  placeholder="..."
                  onChange={(e) =>
                    setDe1({ ...de1, ques_4: e.target.value.toLowerCase() })
                  }
                />
              </div>
            </div>
          </div>
          <div className="flex flex-col items-start mb-5 ques">
            <h4 className="text-black">Ques 5:</h4>
            <div className="flex items-center w-full mb-10 gap-x-5">
              <div className="w-[100px] h-[100px] ">
                <img
                  src={quesIdOne[4]?.Hinh}
                  alt=""
                  className="object-cover w-full h-full rounded-lg"
                />
              </div>
              <div className="flex gap-x-1">
                <label htmlFor="ques" className="text-xl text-black">
                  This is a
                </label>
                <input
                  type="text"
                  id="ques"
                  ref={inpRefFive}
                  className=" outline-none text-xl text-[#ffb86c]"
                  placeholder="..."
                  onChange={(e) =>
                    setDe1({ ...de1, ques_5: e.target.value.toLowerCase() })
                  }
                />
              </div>
            </div>
          </div> */}

        {score >= 0 && (
          <h3 className="font-semibold text-blue-400 ">
            Score: <span className="text-blue-700">{score}/100</span>
          </h3>
        )}
        <div className="flex items-center justify-center gap-x-5">
          <button
            className="px-6 py-3 my-10 rounded-lg bg-gradient-secondary"
            onClick={handleCheck}
          >
            Kiểm tra
          </button>

          {score === 100 ? (
            <button
              className="px-6 py-3 my-10 rounded-lg bg-primary"
              onClick={handleNext}
            >
              Tiếp tục
            </button>
          ) : null}
        </div>
      </div>
    </>
  );
};

// const ItemFill = ({ title, img, onChange }) => {
//   return (
//     <>
//       <div className="flex flex-col items-start ques">
//         <h4 className="text-black">Ques {title}</h4>
//         <div className="flex items-center w-full mb-10 gap-x-5">
//           <div className="w-[100px] h-[100px] ">
//             <img
//               src={img}
//               alt=""
//               className="object-cover w-full h-full rounded-lg"
//             />
//           </div>
//           <div className="flex gap-x-1">
//             <label htmlFor="ques" className="text-xl text-black">
//               This is a
//             </label>
//             <input
//               type="text"
//               id="ques"
//               className=" outline-none text-xl text-[#ffb86c]"
//               placeholder="..."
//               onChange={onChange}
//             />
//           </div>
//         </div>
//       </div>
//     </>
//   );
// };
// {
//   {quesIDOne.map((item, index) => (
//     <ItemFill
//       key={index}
//       title={index + 1}
//       img={item.Hinh}
//       onChange={(e) => {
//         const handleRN=(i)=>{
//           return  `ques_${i}`
//         }
//         const ques_1 = `ques_${index + 1}`;
//         setDe1({ ...de1, ques_1: e.target.value });
//       }}
//     ></ItemFill>
//   ))}

{
  /* <div className="flex flex-col items-start ques">
<h4 className="text-black">Ques 2:</h4>
<div className="flex items-center w-full mb-10 gap-x-5">
  <div className="w-[100px] h-[100px] ">
    <img
      src="https://img.freepik.com/free-vector/vector-pastel-orange-fruit-sticker-cartoon-clipart_53876-173130.jpg?size=338&ext=jpg&uid=R40653510&ga=GA1.2.370007770.1677681756&semt=ais"
      alt=""
      className="object-cover w-full h-full rounded-lg"
    />
  </div>
  <div className="flex gap-x-1">
    <label htmlFor="ques" className="text-xl text-black">
      This is a
    </label>
    <input
      type="text"
      id="ques"
      className=" outline-none text-xl text-[#ffb86c]"
      placeholder="..."
      onChange={(e) => setQuesTwo(e.target.value)}
    />
  </div>
</div>
</div> */
}
export default FillTheWord;
