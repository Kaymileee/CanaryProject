import { Link } from "react-router-dom";
import Button from "../button/Button";
import { useDispatch, useSelector } from "react-redux";
import { logout } from "../../store/user/action";
import { useState } from "react";
import { createPortal } from "react-dom";
import ModelContent from "./ModelContent";

const Header = () => {
  const user = JSON.parse(localStorage.getItem("user"));
  const userInfo = useSelector((state) => state.user.data);
  const dispatch = useDispatch();
  const [show, setShown] = useState(false);
  const handleLogout = () => {
    dispatch(logout());
  };

  return (
    <header className="w-full py-1 pb-5 bg-white border-b-[0.5px]">
      <div className="flex items-center justify-between p-5">
        <Link className="text-3xl font-bold logo" to={"/"}>
          🚀Canary
        </Link>
        {userInfo.length <= 0 ? (
          <div className="flex items-center gap-x-3 ">
            <Button links={"sign-up"} className="border text-slate-700 ">
              Đăng ký
            </Button>
            <Button
              className={"hover:animate-pulse bg-[#00CDC4] text-white"}
              links={"sign-in"}
            >
              Đăng nhập
            </Button>
          </div>
        ) : (
          <div className="relative flex items-center gap-x-3">
            <p
              className={
                "hover:animate-pulse bg-[#00CDC4] text-white px-6 py-3 text-sm font-medium  rounded-lg  text-opacity-1"
              }
              onClick={() => setShown(!show)}
            >
              <img
                src="https://cdn.dribbble.com/userupload/5043407/file/original-e1cdf5b5e01a173fcfe512153c0153a1.png?compress=1&resize=1200x900"
                alt=""
                className="w-full h-full max-w-[40px]  rounded-lg"
              />
            </p>
            {show &&
              createPortal(
                <ModelContent
                  info={user}
                  onClose={() => {
                    setShown(!show);
                  }}
                  onLogout={handleLogout}
                ></ModelContent>,
                document.body
              )}
            {/* <IconLg onClick={handleLogout}></IconLg> */}
          </div>
        )}
      </div>
    </header>
  );
};
export default Header;
