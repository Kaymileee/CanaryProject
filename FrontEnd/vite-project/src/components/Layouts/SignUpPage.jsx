import { useForm } from "react-hook-form";
import { useDispatch } from "react-redux";
import { registerUser } from "../../store/user/action";
import { useNavigate } from "react-router-dom";

const SignUpPage = () => {
  const { register, handleSubmit } = useForm();
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const handleRegister = async (values) => {
    dispatch(registerUser(values));
    navigate("/sign-in");
  };
  return (
    <div className="w-[500px]  bg-white rounded-lg shadow my-10 ">
      <h4 className="p-2 text-xl font-semibold text-center">
        Welcome to Canary
      </h4>
      <p className="text-sm text-center text-slate-400">
        Register to create your first account{" "}
      </p>
      <form
        className="flex flex-col p-5 gap-y-3"
        onSubmit={handleSubmit(handleRegister)}
      >
        <div className="flex flex-col gap-y-1 text-[#6a5af9]">
          <label className="text-[14px] font-semibold" htmlFor="firstName">
            FirstName
          </label>
          <input
            className="px-2 py-3 text-sm rounded-lg outline-none bg-slate-200 text-slate-700"
            type="text"
            id="firstName"
            placeholder="Enter your First Name"
            {...register("firstName")}
          />
        </div>
        <div className="flex flex-col gap-y-1">
          <label
            htmlFor="lastName"
            className="text-[14px] font-semibold text-[#6a5af9]"
          >
            LastName
          </label>
          <input
            className="px-2 py-3 text-sm rounded-lg outline-none bg-slate-200 text-slate-700"
            type="text"
            id="lastName"
            placeholder="Enter your Last Name"
            {...register("lastName")}
          />
        </div>
        <div className="flex flex-col gap-y-1">
          <label
            htmlFor="dob"
            className="text-[14px] font-semibold text-[#6a5af9]"
          >
            Day of birth
          </label>
          <input
            className="px-2 py-3 text-sm rounded-lg outline-none bg-slate-200 text-slate-700"
            type="date"
            id="dob"
            {...register("dob")}
          />
        </div>
        <div className="flex flex-col gap-y-1">
          <label
            htmlFor="username"
            className="text-[14px] font-semibold text-[#6a5af9]"
          >
            User name
          </label>
          <input
            className="px-2 py-3 text-sm rounded-lg outline-none bg-slate-200 text-slate-700"
            type="text"
            id="username"
            placeholder="Enter your User Name"
            {...register("userName")}
          />
        </div>
        <div className="flex flex-col gap-y-1">
          <label
            htmlFor="email"
            className="text-[14px] font-semibold text-[#6a5af9] "
          >
            Email
          </label>
          <input
            className="p-2 text-sm rounded-lg outline-none bg-slate-200 text-slate-700"
            type="email"
            id="email"
            placeholder="Enter your Email Address"
            {...register("email")}
          />
        </div>
        <div className="flex flex-col gap-y-1">
          <label
            htmlFor="password"
            className="text-[14px] font-semibold text-[#6a5af9]"
          >
            Password
          </label>
          <input
            className="p-2 text-sm rounded-lg outline-none bg-slate-200 text-slate-700"
            type="password"
            id="password"
            placeholder="*******"
            {...register("password")}
          />
        </div>
        <div className="flex flex-col gap-y-1">
          <label
            htmlFor="passwordCF"
            className="text-[14px] font-semibold text-[#6a5af9]"
          >
            Password Confirm
          </label>
          <input
            className="p-2 text-sm rounded-lg outline-none bg-slate-200 text-slate-700"
            type="password"
            id="passwordCF"
            placeholder="*******"
            {...register("passwordCF")}
          />
        </div>
        <button className="p-2 my-10 text-white bg-green-500 rounded-lg">
          Register
        </button>
      </form>
    </div>
  );
};

export default SignUpPage;
