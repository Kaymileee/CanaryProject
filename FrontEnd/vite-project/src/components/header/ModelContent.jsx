import { useNavigate } from "react-router-dom";
import IconLogout from "../icons/IconLogout";
import IconSeeting from "../icons/IconSeeting";

const ModelContent = ({ info, onClose, onLogout }) => {
  const navigate = useNavigate();

  return (
    <div className="absolute bg-slate-100 shadow rounded-lg right-2 top-[80px] modal w-[300px] flex items-start flex-col p-5 gap-y-2 z-50">
      <div
        className="absolute flex items-center justify-center w-5 h-5 text-white bg-red-600 rounded-full cursor-pointer top-1 right-2"
        onClick={onClose}
      >
        X
      </div>
      <div className="flex w-full pb-2 space-x-2 border-b-2">
        <img
          src="https://cdn.dribbble.com/userupload/5043407/file/original-e1cdf5b5e01a173fcfe512153c0153a1.png?compress=1&resize=1200x900"
          alt=""
          className="w-full h-full max-w-[40px]  rounded-lg"
        />
        <h2 className="text-xl font-semibold">I'm {info.userName} </h2>
      </div>
      <div className="flex flex-col px-4 gap-y-1">
        <h3>{info.email}</h3>
        <p>{`${info.firstName} ${info.lastName}`}</p>
        <h3>{info.levelName}</h3>
      </div>
      <button
        onClick={() => navigate("/user/info")}
        className="flex items-center w-full max-w-full text-white rounded-lg gap-x-2 hover:bg-slate-200 h-[50px] px-2"
      >
        <IconSeeting></IconSeeting> <span className="text-black">Cài đặt</span>
      </button>
      <button
        onClick={onLogout}
        className="flex items-center w-full max-w-full text-white rounded-lg gap-x-2 hover:bg-slate-200 h-[50px] px-2"
      >
        <IconLogout></IconLogout> <span className="text-black">Đăng xuất</span>
      </button>
      {/* <button className="w-full p-3 text-white bg-[#00CDC4] rounded-lg max-w-[70px]">
          Edit
        </button> */}
    </div>
  );
};

export default ModelContent;
