import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import IconVl from "../icons/IconVl";
const ItemVoc = ({ name, img }) => {
  const msg = new SpeechSynthesisUtterance();

  const handleSpeak = (msg) => {
    msg.text = name;
    window.speechSynthesis.speak(msg);
  };
  const [vocTrans, setVocTrans] = useState("");
  const encodedParams = new URLSearchParams();
  encodedParams.append("source_language", "en");
  encodedParams.append("target_language", "vi");
  encodedParams.append("text", name);

  const options = {
    method: "POST",
    headers: {
      "content-type": "application/x-www-form-urlencoded",
      "X-RapidAPI-Key": "ee07226633msh227d5acadff5384p1fb98ejsn50ea09922fa7",
      "X-RapidAPI-Host": "text-translator2.p.rapidapi.com",
    },
    body: encodedParams,
  };

  // useEffect(() => {
  //   const handleFetch = () => {
  //     fetch("https://text-translator2.p.rapidapi.com/translate", options)
  //       .then((response) => response.json())
  //       .then((response) => setVocTrans(response.data.translatedText))
  //       .catch((err) => console.error(err));
  //   };
  //   handleFetch();
  // }, []);
  return (
    <div className="w-[350px] p-5 flex items-center flex-col border rounded-lg bg-white h-[350px] justify-center">
      <img src={img} alt="" className="object-cover h-[150px] " />
      <div className="flex my-10 gap-x-1">
        <h5 className="text-xl font-semibold text-blue-700">{name}</h5>
        <h5 className="text-xl font-semibold text-blue-300">({vocTrans})</h5>
      </div>

      <IconVl
        className={"cursor-pointer"}
        onClick={() => handleSpeak(msg)}
      ></IconVl>
    </div>
  );
};

export default ItemVoc;
