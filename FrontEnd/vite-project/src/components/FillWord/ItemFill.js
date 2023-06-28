import React, { useEffect, useRef } from "react";

const ItemFill = ({ item, setDe1, index, de1, next }) => {
  const handleChoice = (e, n) => {
    switch (n) {
      case 0:
        setDe1({ ...de1, ques_1: e.target.value });

        break;
      case 1:
        setDe1({ ...de1, ques_2: e.target.value });

        break;
      case 2:
        setDe1({ ...de1, ques_3: e.target.value });

        break;
      case 3:
        setDe1({ ...de1, ques_4: e.target.value });

        break;
      case 4:
        setDe1({ ...de1, ques_5: e.target.value });

        break;
      default:
        break;
    }
  };
  const inpRef = useRef();
  useEffect(() => {
    inpRef.current.value = "";
  }, [next]);
  return (
    <div className="flex flex-col items-start p-5 mb-5 rounded-lg shadow ques">
      <h4 className="text-2xl font-semibold text-black">
        Câu hỏi số {index + 1}:
      </h4>
      <div className="flex items-center w-full mb-10 gap-x-5">
        <div className="w-[200px] h-[200px]">
          <img
            src={item.Hinh}
            alt=""
            className="object-contain w-full h-full rounded-lg"
          />
        </div>
        <div className="flex gap-x-1">
          <label htmlFor="ques" className="text-xl text-black">
            {item.CH ? item.CH : "Đây là gì"}
          </label>
          <input
            ref={inpRef}
            type="text"
            id="ques"
            className=" outline-none text-xl text-[#ffb86c] font-medium"
            placeholder="..."
            onChange={(e) => handleChoice(e, index)}
          />
        </div>
      </div>
    </div>
  );
};

export default ItemFill;
