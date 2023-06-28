import { useEffect } from "react";
import { useForm } from "react-hook-form";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";

const UserInfoPage = () => {
  const { handleSubmit, register, reset, setValue } = useForm();
  const userInfo = useSelector((state) => state.user.data);
  const navigate = useNavigate();
  function convertDate(inputFormat) {
    function pad(s) {
      return s < 10 ? "0" + s : s;
    }
    var d = new Date(inputFormat);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join("/");
  }

  useEffect(() => {
    // const userInfo = localStorage.getItem("user");
    // const user = JSON.parse(userInfo);
    if (userInfo.length <= 0) {
      navigate("/sign-in");
    }
    reset(userInfo);
    // setValue("dob", convertDate(user.dob));
  }, [userInfo]);
  const submitt = (values) => {
    console.log(values);
  };

  return (
    <div className="bg-[#F9F9F9] w-full h-screen flex items-center justify-center py-20">
      <div className="max-w-[1080px] w-full h-[500px] p-20 border mx-auto bg-white flex rounded-lg">
        <div className="flex flex-col pr-2 border-r-2 gap-y-1">
          <h3 className="text-xs font-semibold uppercase text-[rgb(60, 60, 60);] mb-2">
            Basic Information
          </h3>
          <div className="w-[100px] h-[100px] bg-purple-500 rounded-full"></div>
        </div>
        <div className="flex-1 p-5 max-w-[500px] w-full">
          <form onSubmit={handleSubmit(submitt)}>
            <div className="flex justify-between">
              <div className="flex flex-col gap-y-1">
                <label
                  htmlFor="firstName"
                  className="text-[#696969] text-[13px] font-bold pb-3"
                >
                  First Name
                </label>
                <input
                  id="firstName"
                  type="text"
                  className="p-2 border rounded-md outline-none"
                  {...register("firstName")}
                />
              </div>
              <div className="flex flex-col gap-y-1">
                <label
                  htmlFor="lastName"
                  className="text-[#696969] text-[13px] font-bold pb-3"
                >
                  Last Name
                </label>
                <input
                  id="lastName"
                  type="text"
                  className="p-2 border rounded-md outline-none"
                  {...register("lastName")}
                />
              </div>
            </div>
            <div className="flex gap-x-5">
              <div className="flex flex-col flex-1 gap-y-1">
                <label
                  htmlFor="firstName"
                  className="text-[#696969] text-[13px] font-bold pb-3"
                >
                  User name
                </label>
                <input
                  id="username"
                  type="text"
                  className="p-2 border rounded-md outline-none"
                  {...register("userName")}
                />
              </div>
            </div>
            <div className="flex items-center justify-between my-5 gap-x-5">
              <div className="flex flex-col gap-y-1 ">
                <label
                  htmlFor="dob"
                  className="text-[#696969] text-[13px] font-bold pb-3"
                >
                  Day of birth
                </label>
                <input
                  id="dob"
                  type="text"
                  className="p-2 border rounded-md outline-none"
                  {...register("dob")}
                />
              </div>
              <div className="flex flex-col gap-y-1">
                <label
                  htmlFor="level"
                  className="text-[#696969] text-[13px] font-bold pb-3"
                >
                  Level
                </label>
                <input
                  id="level"
                  type="text"
                  disabled
                  className="p-2 border rounded-md outline-none"
                  {...register("levelName")}
                />
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default UserInfoPage;
