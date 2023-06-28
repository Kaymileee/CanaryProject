import { useCallback, useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { getVocabularies } from "../store/vocabularies/action";
import IconSpeaker from "../components/icons/IconSpeaker";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/css";
import "swiper/css/navigation";
import { Navigation } from "swiper";
import IconNext from "../components/icons/IconNext";
import IconPrev from "../components/icons/IconPrev";
import { createPortal } from "react-dom";
const TopicDesc = () => {
  const { topicId } = useParams();
  const vocabularies = useSelector((state) => state.vocabularies.data);
  const [voccabulariesLength, setVocabulariesLength] = useState(1);
  const dispatch = useDispatch();
  const [open, setOpen] = useState(false);
  const navigate = useNavigate();
  useEffect(() => {
    if (localStorage.getItem("user")) {
      dispatch(getVocabularies(topicId));
    } else {
      navigate("/sign-in");
    }
  }, []);
  const sliderRef = useRef(null);
  const navigationPrevRef = useRef(null);
  const navigationNextRef = useRef(null);
  const handlePrev = useCallback(() => {
    if (!sliderRef.current) return;
    setVocabulariesLength((prev) => prev - 1);

    sliderRef.current.swiper.slidePrev();
  }, []);

  const handleNext = useCallback(() => {
    if (!sliderRef.current) return;

    setVocabulariesLength((prev) => prev + 1);
    if (voccabulariesLength == vocabularies.length - 1) {
      setOpen(true);
    }
    sliderRef.current.swiper.slideNext();
  }, [voccabulariesLength]);
  return (
    <div className="h-screen my-20">
      <div>
        <div className="flex items-center gap-x-5">
          <p
            htmlFor="minmax-range"
            className="block mb-2 text-3xl font-semibold text-gray-600 dark:text-[#CDCDCD]"
          >
            {`${voccabulariesLength}/${vocabularies.length}`}
          </p>
          <input
            id="minmax-range"
            type="range"
            min={1}
            max={vocabularies.length}
            defaultValue={voccabulariesLength}
            className="w-full h-5 bg-gray-200 rounded-lg appearance-none cursor-pointer dark:bg-blue-200"
            onChange={(e) => {
              setVocabulariesLength(Number(e.target.value));
              sliderRef.current.swiper.slideNext(Number(e.target.value));
            }}
          />
        </div>
      </div>
      <Swiper
        navigation={{
          prevEl: navigationPrevRef.current,
          nextEl: navigationNextRef.current,
        }}
        modules={[Navigation]}
        className="mySwiper max-w-[1000px] h-[500px]"
        ref={sliderRef}
      >
        {vocabularies.length > 0 &&
          vocabularies.map((vocabulary) => (
            <SwiperSlide key={vocabulary.vocId}>
              <VocabularyItem item={vocabulary}></VocabularyItem>
            </SwiperSlide>
          ))}
      </Swiper>
      <div className="fixed w-full h-[100px] bg-slate-100 left-0 bottom-0 z-50 justify-between flex items-center px-[200px]">
        <div
          onClick={handlePrev}
          className={`flex cursor-pointer gap-x-2 ${
            voccabulariesLength == 1 ? "pointer-events-none opacity-50" : ""
          } `}
        >
          <IconPrev></IconPrev>
          <p className="text-3xl text-slate-600">Quay lại</p>
        </div>
        <div
          className={`flex cursor-pointer gap-x-2 ${
            voccabulariesLength == vocabularies.length
              ? "pointer-events-none opacity-50"
              : ""
          } `}
          onClick={handleNext}
        >
          <p className="text-3xl text-slate-600">Tiếp tục</p>
          <IconNext></IconNext>
        </div>
        {voccabulariesLength == vocabularies.length && open
          ? createPortal(
              <ModelExercise
                titleTopic={topicId}
                setOpen={setOpen}
                open={open}
              ></ModelExercise>,
              document.body
            )
          : undefined}
      </div>
    </div>
  );
};

function ModelExercise({ titleTopic, setOpen, open }) {
  const hadnleStudy = () => {
    setOpen(false);
  };
  const navigate = useNavigate();
  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-80 modelExe">
      <div className=" h-[500px] bg-white rounded-lg p-10 max-w-[500px] w-full ">
        <img
          src="https://img.freepik.com/free-vector/illustrated-business-person-meditating_52683-60757.jpg?size=626&ext=jpg&ga=GA1.1.12167484.1678342596&semt=sph"
          alt=""
          className="h-[200px] mx-auto rounded-lg"
        />
        <div className="flex flex-col items-center">
          <h3 className="text-[20px] text-[#4C4C4C] mt-[35px] ">
            Bạn vừa hoàn thành phần từ vựng phần
          </h3>
          <h1 className="font-bold text-[40px] text-green-500">
            {titleTopic.slice(2)}
          </h1>
        </div>
        <div className="flex items-center justify-between">
          <button
            className="px-5 py-4 font-semibold text-green-500 transition-all bg-white border rounded-md hover:opacity-75"
            onClick={hadnleStudy}
          >
            Học tiếp
          </button>
          <button
            className="px-5 py-4 font-semibold text-white transition-all bg-green-500 rounded-md hover:opacity-75"
            onClick={() => navigate(`/Exam/${titleTopic}`)}
          >
            Kiểm tra
          </button>
        </div>
      </div>
    </div>
  );
}
function VocabularyItem({ item }) {
  const msg = new SpeechSynthesisUtterance();
  const handleSpeak = (word) => {
    msg.text = word;
    window.speechSynthesis.speak(msg);
  };
  return (
    <div className="flex items-center justify-start w-full h-full gap-5 p-5 border rounded-lg">
      {/* img */}
      <div className="max-w-[350px] max-h-[300px] bg-white p-2 rounded-lg w-full h-full">
        <img
          // eslint-disable-next-line react/prop-types
          src={item.vocImgUrl}
          alt=""
          className="object-cover w-full h-full"
        />
      </div>
      <div className="flex flex-col items-start text-2xl gap-y-2">
        <h4 className="text-[#41BDF8] font-bold">
          {item.wordVoc.toUpperCase()}
        </h4>
        <div className="flex flex-col items-start gap-x-2 gap-y-4">
          <div className="flex items-start justify-start gap-x-2">
            <div
              className="p-2 bg-[#41BDF8] text-white rounded-lg cursor-pointer"
              onClick={() => handleSpeak(item.wordVoc)}
            >
              <IconSpeaker></IconSpeaker>
            </div>
            <p className="text-3xl font-semibold text-[#777777]">
              {item.vocIPA}
            </p>
          </div>
          <div className="text-2xl font-semibold text-[#9d9d9d] block text-left">
            Example: {item.vocExample}
          </div>
        </div>
      </div>
    </div>
  );
}
export default TopicDesc;
