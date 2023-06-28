import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

const TopicsPage = () => {
  const [topics, setTopics] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    const getAllTopics = async () => {
      const res = await axios.get(
        "https://localhost:5000/api/Topics/getAllTopics"
      );
      const data = res.data.resultObj;
      setTopics(data);
    };
    getAllTopics();
  }, []);

  return (
    <div className="w-full p-10">
      <div className="">
        <div className="w-full h-[670px] rounded-lg relative overflow-hidden ">
          <img
            src="https://img.freepik.com/free-photo/beautiful-shot-tower-bridge-london_181624-833.jpg?w=1060&t=st=1683473643~exp=1683474243~hmac=1db701779af1e2bec9222fe79ca0331c30a4cdccb5f5f1280ca877fe97d35b0a"
            alt=""
            className="w-full h-full rounded-lg"
          />
          <div className="absolute inset-0 z-20 w-full h-full bg-black bg-opacity-90"></div>
          <div className="absolute z-30 text-white top-2/4 left-2/4">
            <h1 className="text-3xl italic font-bold uppercase">Topics</h1>
          </div>
        </div>
      </div>
      <div className="my-10">
        <div className="text-left ">
          <div className="w-10 h-1 my-2 primary line"></div>
          <h3 className="text-2xl font-bold uppercase">Level 1</h3>
        </div>
        <div className="grid grid-cols-4 gap-5 mt-5 ">
          {topics &&
            topics.length > 0 &&
            topics.map((topic) => (
              <div
                className="flex items-center gap-5 p-2 border rounded-lg cursor-pointer"
                key={topic.topicId}
                onClick={() => navigate(`${topic.topicId}`)}
              >
                <div className="w-20 h-20 bg-red-500 rounded-lg">
                  <img
                    src={topic.topicDesc}
                    alt=""
                    className="object-cover w-full h-full"
                  />
                </div>
                <div className="flex flex-col">
                  <h5 className="font-semibold">{topic.nameTopic}</h5>
                </div>
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default TopicsPage;
