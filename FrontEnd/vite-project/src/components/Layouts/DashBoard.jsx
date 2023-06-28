import , { useState } from "react";
import { Link, Outlet, Route } from "react-router-dom";

const DashBoard = ({ children }) => {
  return (
    <>
      <div className="container h-screen py-20">
        <div className="flex items-center my-5 gap-x-5">
          <Link
            to={"/"}
            className="p-4 text-slate-700 transition-colors bg-transparent rounded-lg border-[1px] hover:text-red-600 "
          >
            Quay lại
          </Link>
          <Link
            to={"/multiple-choice"}
            className="p-4 text-white transition-colors rounded-lg bg-[#4F67FF] hover:bg-opacity-80 "
          >
            Trắc nghiệm
          </Link>
          <Link
            to={"/fill-in-the-word"}
            className="p-4 text-white transition-colors rounded-lg bg-[#4F67FF] hover:bg-opacity-80 "
          >
            Điền từ
          </Link>
        </div>
        {/* {children} */}
        {/* <div className="flex flex-col max-w-[500px] gap-2">
          <Link to={""}>
            <h3 className="bg-[#CCEDCB] w-auto p-3 rounded-md text-blue-500">
              Chơi theo chủ đề toán học
            </h3>
          </Link>
          <Link to={""}>
            <h3 className="bg-[#CCEDCB] w-auto p-3 rounded-md text-blue-500">
              Chơi theo chủ đề trái cây
            </h3>
          </Link>
        </div> */}
      </div>
    </>
  );
};

export default DashBoard;
{
  /*  */
}
