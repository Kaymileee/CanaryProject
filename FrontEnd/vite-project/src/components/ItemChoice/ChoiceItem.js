import React, { useRef } from "react";

const ChoiceItem = ({ item, onClick, setChoice, index, choice, reff }) => {
  const handleChoice = (e, n) => {
    switch (n) {
      case 0:
        setChoice({ ...choice, ques_1: e.target.value });

        break;
      case 1:
        setChoice({ ...choice, ques_2: e.target.value });

        break;
      case 2:
        setChoice({ ...choice, ques_3: e.target.value });

        break;
      case 3:
        setChoice({ ...choice, ques_4: e.target.value });

        break;
      case 4:
        setChoice({ ...choice, ques_5: e.target.value });

        break;
      default:
        break;
    }
  };

  return (
    <div className="flex p-5 my-10 rounded-lg shadow gap-x-5">
      <div className="w-[250px] h-[150px]">
        <img src={item.Hinh} alt="" className="w-full h-full rounded-lg" />
      </div>
      <div className="text-left text-black">
        <h4 className="my-10 text-xl font-semibold uppercase text-slate-700">
          {item.CH}
        </h4>
        <div className="flex items-center justify-between gap-x-5">
          <label className="flex items-center text-xl gap-x-2">
            <input
              type="radio"
              name={`answer${index}`}
              onClick={(e) => handleChoice(e, index)}
              value="A"
              className="w-5 h-5 "
            />
            <span>{item.A}</span>
          </label>
          <label className="flex items-center text-xl gap-x-2">
            <input
              type="radio"
              name={`answer${index}`}
              onClick={(e) => handleChoice(e, index)}
              value="B"
              className="w-5 h-5 "
            />
            <span>{item.B}</span>
          </label>
          <label className="flex items-center text-xl gap-x-2">
            <input
              type="radio"
              name={`answer${index}`}
              onClick={(e) => handleChoice(e, index)}
              value="C"
              className="w-5 h-5 "
            />
            <span>{item.C}</span>
          </label>
        </div>
      </div>
    </div>
  );
};

export default ChoiceItem;
