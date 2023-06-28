import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { loginUser, newPassword, sendCode } from "../../store/user/action";
import { createPortal } from "react-dom";
const LoginPage = () => {
  const [user, setUser] = useState({ userName: "", password: "" });
  const [showForgotPassword, setShowForgotPassword] = useState(false);
  const [email, setEmail] = useState("");
  const [check, setCheck] = useState(false);
  const [code, setCode] = useState("");
  const [password, setPassword] = useState("");
  const [passwordCF, setPasswordCF] = useState("");

  const dispatch = useDispatch();
  const navigate = useNavigate();
  // const userRedux = useSelector((state) => state.user);
  const handleLogin = async () => {
    dispatch(loginUser(user));
    navigate("/");
  };
  // useEffect(() => {
  //   if (!Array.isArray(userRedux?.data)) {
  //     navigate("/");
  //   }
  // }, [userRedux]);
  useEffect(() => {
    if (localStorage.getItem("login")) {
      const parseData = JSON.parse(localStorage.getItem("login"));
      setUser(parseData);
      setCheck(true);
    }
  }, []);
  const handlePassword = (e) => {
    e.preventDefault();
    const data = { email, code, password, passwordCF };
    dispatch(newPassword(data));
    navigate("/");
  };
  const handleSendCode = (e) => {
    e.preventDefault();
    dispatch(sendCode(email));
    const currentForm = document.querySelector(".sendForm");
    currentForm.classList.add("hidden");
  };
  const handleRemember = () => {
    // console.log(JSON.stringify(user));
    setCheck(!check);
    if (!check) {
      localStorage.setItem("login", JSON.stringify(user));
    } else {
      localStorage.removeItem("login");
    }
  };
  return (
    <>
      <div className="container flex flex-col items-center justify-center py-20 gap-y-5">
        <form className="w-full max-w-[500px] rounded-lg shadow-md bg-white h-[400px] flex flex-col p-5">
          <div className="text-field">
            <label htmlFor="username">Username</label>
            <input
              type="text"
              id="username"
              placeholder="Enter your username"
              onChange={(e) => setUser({ ...user, userName: e.target.value })}
              className="focus:border-[#6a5af9] focus:border-b"
              defaultValue={user.userName}
            />
          </div>
          <div className="text-field ">
            <label htmlFor="password">Password</label>
            <input
              autoComplete="off"
              type="password"
              id="password"
              defaultValue={user.password}
              onChange={(e) => setUser({ ...user, password: e.target.value })}
              className="focus:border-[#6a5af9] focus:border-b"
            />
          </div>
          <div className="flex items-center justify-between px-5 py-2">
            <div className="flex items-center gap-x-1">
              <input
                type="checkbox"
                id="remember"
                checked={check}
                onClick={handleRemember}
                defaultChecked={check}
              />
              <label
                htmlFor="remember"
                className="text-sm font-normal cursor-pointer text-slate-500"
              >
                Remember me
              </label>
            </div>
            <div>
              <p
                to={"/forgot_password"}
                className="text-sm font-normal cursor-pointer text-slate-500"
                onClick={() => setShowForgotPassword(!showForgotPassword)}
              >
                Forgot password ?
              </p>
            </div>
          </div>
          <div className="flex mt-auto gap-x-5">
            <Link
              to={"/"}
              className={
                "bg-transparent w-full mt-auto px-6 py-3 text-sm font-medium text-slate-700 rounded-lg  text-opacity-1  border text-center"
              }
            >
              Hủy
            </Link>
            <button
              type="submit"
              className={
                "bg-gradient-secondary w-full mt-auto px-6 py-3 text-sm font-medium text-white rounded-lg  text-opacity-1"
              }
              onClick={handleLogin}
            >
              Đăng nhập
            </button>
          </div>
        </form>
      </div>
      {showForgotPassword &&
        createPortal(
          <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-60">
            <div className="relative ">
              <div
                className="absolute text-red-600 cursor-pointer right-2 top-2"
                onClick={() => setShowForgotPassword(!showForgotPassword)}
              >
                X
              </div>
              <form className="bg-white w-[500px]  rounded-lg p-5 flex flex-col gap-4">
                <div className="flex flex-col space-y-1 sendForm">
                  <label
                    htmlFor="email"
                    className="font-semibold cursor-pointer"
                  >
                    Email
                  </label>

                  <input
                    type="text"
                    placeholder="Enter your email "
                    className="p-2 border-0 rounded-lg outline-none bg-slate-200"
                    id="email"
                    autoComplete="false"
                    onChange={(e) => setEmail(e.target.value)}
                  />
                  <button
                    type="submit"
                    className="p-2 text-white bg-[#00CDC4] rounded-lg hover:bg-opacity-80 transition-all"
                    onClick={handleSendCode}
                  >
                    Send code
                  </button>
                </div>

                <div className="flex flex-col space-y-1">
                  <label
                    htmlFor="email"
                    className="font-semibold cursor-pointer"
                  >
                    Email
                  </label>

                  <input
                    type="text"
                    placeholder="Enter your email "
                    className="p-2 border-0 rounded-lg outline-none bg-slate-200"
                    id="email"
                    autoComplete="false"
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </div>
                <div className="flex flex-col space-y-1">
                  <label
                    htmlFor="code"
                    className="font-semibold cursor-pointer"
                  >
                    Code
                  </label>

                  <input
                    type="password"
                    placeholder="Enter your email "
                    className="p-2 border-0 rounded-lg outline-none bg-slate-200"
                    id="code"
                    autoComplete="false"
                    onChange={(e) => setCode(e.target.value)}
                  />
                </div>
                <div className="flex flex-col space-y-1">
                  <label
                    htmlFor="password"
                    className="font-semibold cursor-pointer"
                  >
                    New Password
                  </label>

                  <input
                    type="password"
                    placeholder="Enter your email "
                    className="p-2 border-0 rounded-lg outline-none bg-slate-200"
                    id="password"
                    autoComplete="false"
                    onChange={(e) => setPassword(e.target.value)}
                  />
                </div>
                <div className="flex flex-col space-y-1">
                  <label
                    htmlFor="confirm_password"
                    className="font-semibold cursor-pointer"
                  >
                    Confirm Password
                  </label>

                  <input
                    type="text"
                    placeholder="Enter your email "
                    className="p-2 border-0 rounded-lg outline-none bg-slate-200"
                    id="confirm_password"
                    autoComplete="false"
                    onChange={(e) => setPasswordCF(e.target.value)}
                  />
                </div>

                <button
                  type="submit"
                  className="p-2 text-white bg-[#00CDC4] rounded-lg hover:bg-opacity-80 transition-all"
                  onClick={handlePassword}
                >
                  Register Password
                </button>
              </form>
            </div>
          </div>,
          document.body
        )}
    </>
  );
};

export default LoginPage;
