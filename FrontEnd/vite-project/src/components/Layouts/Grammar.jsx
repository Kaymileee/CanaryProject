import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { collection, getDocs } from "firebase/firestore";
import { db } from "../../firebaseConfig/fbConfig";
import { useAuth } from "../../context/authContext";
import LoginPage from "./LoginPage";
const Grammar = () => {
  const { userInfo } = useAuth();
  const navigate = useNavigate();
  const [topics, setTopics] = useState([]);
  // get topic from Fbase ---topic(name,img)

  const colRef = collection(db, "TopicVoc");
  useEffect(() => {
    async function getTopicVoc() {
      const results = [];
      const docsSnap = await getDocs(colRef);
      docsSnap.forEach((doc) => {
        results.push(doc.data());
      });
      setTopics(results);
    }
    getTopicVoc();
  }, []);
  if (!userInfo) {
    return <LoginPage></LoginPage>;
  }
  return (
    <div className="w-full p-5">
      <div className="h-screen py-10 text-black bg-white rounded-lg">
        <h3 className="mb-10 text-3xl font-bold text-center text-[#FA7070]">
          Topics
        </h3>
        <div className="flex items-center gap-x-2 gap-y-5 justify-evenly">
          {topics.length > 0 &&
            topics.map((topic) => (
              <div
                className="h-[300px]  rounded-md w-[300px] relative cursor-pointer  transition-all z-10 bg-white shadow-sm border p-5"
                onClick={() => navigate(topic.TopicName)}
                key={topic.TopicId}
              >
                <div className="w-full h-[200px] ">
                  <img
                    src={topic.TopicImg}
                    alt=""
                    className="object-cover w-full h-full rounded-full"
                  />
                </div>

                <div className="absolute bottom-0 z-30 p-2 text-2xl font-medium bg-[#FBF2CF] text-[#fa7070a7] rounded-md left-2/4 -translate-x-2/4 w-full">
                  {topic.TopicName}
                </div>
              </div>
            ))}
        </div>
      </div>
    </div>
  );
};

export default Grammar;
