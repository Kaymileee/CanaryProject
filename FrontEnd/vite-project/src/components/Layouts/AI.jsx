import { useState, useEffect, useRef } from "react";
import * as mobilenet from "@tensorflow-models/mobilenet";
import IconVl from "../icons/IconVl";
import IconSpeaker from "../icons/IconSpeaker";

const AI = () => {
  const [isModelLoading, setIsModelLoading] = useState(false);
  const [model, setModel] = useState(null);
  const [imageURL, setImageURL] = useState(null);
  const [results, setResults] = useState([]);
  const [history, setHistory] = useState([]);
  const imageRef = useRef();
  const textInputRef = useRef();
  const fileInputRef = useRef();
  const [res, setRes] = useState();
  const [txtTrans, setTxtTrans] = useState("");

  const loadModel = async () => {
    setIsModelLoading(true);
    try {
      const model = await mobilenet.load();
      setModel(model);
      setIsModelLoading(false);
    } catch (error) {
      console.log(error);
      setIsModelLoading(false);
    }
  };

  const uploadImage = (e) => {
    const { files } = e.target;
    if (files.length > 0) {
      const url = URL.createObjectURL(files[0]);
      setImageURL(url);
    } else {
      setImageURL(null);
    }
  };

  const identify = async () => {
    textInputRef.current.value = "";
    const results = await model.classify(imageRef.current);
    setResults(results);
    setRes(results[0]);
  };
  const handleOnChange = (e) => {
    setImageURL(e.target.value);
    setResults([]);
  };

  const triggerUpload = () => {
    fileInputRef.current.click();
  };

  useEffect(() => {
    loadModel();
  }, []);

  useEffect(() => {
    if (imageURL) {
      setHistory([imageURL, ...history]);
    }
  }, [imageURL]);

  if (isModelLoading) {
    return (
      <>
        <div className="p-10 border-[#00CDC4] rounded-full border-[5px] animate-spin border-t-transparent"></div>
      </>
    );
  }

  // let trans = res?.className;
  // const encodedParams = new URLSearchParams();
  // encodedParams.append("source_language", "en");
  // encodedParams.append("target_language", "vi");
  // encodedParams.append("text", trans);

  // const options = {
  //   method: "POST",
  //   headers: {
  //     "content-type": "application/x-www-form-urlencoded",
  //     "X-RapidAPI-Key": "ee07226633msh227d5acadff5384p1fb98ejsn50ea09922fa7",
  //     "X-RapidAPI-Host": "text-translator2.p.rapidapi.com",
  //   },
  //   body: encodedParams,
  // };

  // useEffect(() => {
  //   const handleFetch = () => {
  //     fetch("https://text-translator2.p.rapidapi.com/translate", options)
  //       .then((response) => response.json())
  //       .then((response) => setTxtTrans(response.data.translatedText))
  //       .catch((err) => console.error(err));
  //   };
  //   handleFetch();
  // }, []);
  const msg = new SpeechSynthesisUtterance();
  const handleSpeak = (word) => {
    msg.text = word;
    window.speechSynthesis.speak(msg);
  };
  return (
    <div className="container h-screen my-10 border rounded-lg bg-[#CCEDCB]">
      <h1 className="py-10 text-2xl font-bold text-[#00CDC4] text-center">
        Phân tích vật thể sang tiếng anh
      </h1>
      <div className="flex flex-col items-center justify-between">
        <div className="flex items-center justify-center w-auto gap-x-3 max-w-[300px] w-full">
          <input
            id="choose"
            type="file"
            accept="image/*"
            capture="camera"
            className="hidden uploadInput"
            onChange={uploadImage}
            ref={fileInputRef}
          />
          <label
            htmlFor="choose"
            className="w-full p-3 font-medium bg-white rounded-lg cursor-pointer "
          >
            Chọn Tệp
          </label>
          {imageURL && (
            <label
              className="w-full p-3 text-white bg-black rounded-lg cursor-pointer"
              onClick={() => identify()}
            >
              Phân tích
            </label>
          )}
          {/* <button className="uploadImage" onClick={triggerUpload}>
            Upload Image
          </button> */}
        </div>
        <span className="hidden or">OR</span>
        <input
          type="text"
          className="hidden"
          placeholder="Paster image URL"
          ref={textInputRef}
          onChange={handleOnChange}
        />
      </div>
      <div className="flex items-start justify-center my-5 mainWrapper gap-x-2">
        <div className="flex items-start justify-center mainContent gap-x-5 ">
          <div className="imageHolder w-[400px] h-[300px] overflow-hidden rounded-lg flex items-center justify-center ">
            {imageURL && (
              <img
                src={imageURL}
                alt="Upload Preview"
                crossOrigin="anonymous"
                ref={imageRef}
                className="object-contain w-full h-full rounded-lg"
              />
            )}
          </div>
          {results.length > 0 && (
            <div className="my-5 font-medium text-slate-900 resultsHolder max-w-[400px] w-full text-left">
              {/*  */}
              {results[0] && (
                <div className="flex justify-between result gap-x-4">
                  <span className="w-full name">{results[0].className}</span>
                  <div
                    className="p-2 bg-[#41BDF8] text-white rounded-lg cursor-pointer"
                    onClick={() => handleSpeak(results[0].className)}
                  >
                    <IconSpeaker></IconSpeaker>
                  </div>
                  <span className="confidence max-w-[200px] w-full">
                    Độ Chính Xác: {(results[0].probability * 100).toFixed(2)}%{" "}
                    {/* {index === 0 && (
                        <span className="bestGuess">Best Guess</span>
                      )} */}
                  </span>
                </div>
              )}
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

//   {results.map((result) => {
//   return (
//     <div
//       className="flex justify-between result gap-x-4"
//       key={result.className}
//     >
//       <span className="w-full name">{result.className}</span>
//       <span className="confidence max-w-[200px] w-full">
//         Độ Chính Xác: {(result.probability * 100).toFixed(2)}%{" "}
//         {/* {index === 0 && (
//           <span className="bestGuess">Best Guess</span>
//         )} */}
//       </span>
//     </div>
//   );
// })}
export default AI;
