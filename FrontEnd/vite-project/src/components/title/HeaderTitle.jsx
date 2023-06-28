/* eslint-disable react/no-unescaped-entities */
import { useSelector } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
const dataDummies = [
  {
    title: "Image Recognition",
    img: "https://img.freepik.com/free-vector/people-using-search-box-query-engine-giving-result_74855-11000.jpg?w=996&t=st=1679405907~exp=1679406507~hmac=0b432c739de35e2976ad6999553dbd81262d6e9b3e4786db204b763ed4a802a4",
    link: "AI",
  },
  // {
  //   title: "Exercises",
  //   img: "https://img.freepik.com/free-vector/hand-drawn-kids-playing-background_23-2148060869.jpg?size=338&ext=jpg&uid=R40653510&ga=GA1.1.12167484.1678342596&semt=sph",
  //   link: "Exercise",
  // },
  {
    title: "Vocabularies",
    img: "https://img.freepik.com/free-vector/learning-concept-illustration_114360-6186.jpg?size=338&ext=jpg&uid=R40653510&ga=GA1.1.12167484.1678342596&semt=sph",
    link: "Topics",
  },
];
const HeaderTitle = () => {
  const navigate = useNavigate();
  const user = useSelector((state) => state.user);
  console.log(user);
  return (
    <>
      <div className="flex  items-center justify-center py-20 bg-[#8CA3FE] container rounded-lg gap-20">
        <div className="flex flex-col items-start">
          <h1 className="mx-auto mb-10 text-3xl font-semibold leading-snug text-left text-white lg:leading-relaxed lg:text-4xl">
            Test-English <br></br>
            <span className="txt-primary">Take your learning with you!</span>
          </h1>
          <Link
            className="inline-flex items-center justify-center gap-x-3 px-8 py-4 font-sans font-semibold tracking-wide text-white bg-gradient-secondary rounded-lg h-[60px] w-full sm:w-[230px] button-effect text-left"
            to={"/exercise"}
          >
            Let's Go
          </Link>
        </div>

        <img
          src="https://img.freepik.com/free-vector/hand-drawn-back-school-illustration_23-2149479527.jpg?t=st=1679398592~exp=1679399192~hmac=564c2f10d1c0bb6ae4b01b9c7465a2f5aabc5f3a3f3a703ddf5c7e8e53c7eeff"
          alt=""
          className="rounded-lg"
        />
      </div>
      <div className="container my-10">
        <div className="mt-10 mb-5 text-left">
          <div className="w-10 h-1 my-2 primary line"></div>
          <h3 className="text-2xl font-bold uppercase">Our program</h3>
        </div>
        <div className="grid grid-cols-4 transition-all gap-x-5 dataDumies">
          {dataDummies.map((item, index) => (
            <div
              className="relative rounded-lg shadow-md cursor-pointer item"
              key={index}
              onClick={() => navigate(`/${item.link}`)}
            >
              <div className="w-full h-[350px] filter transition">
                <img
                  src={item.img}
                  alt=""
                  className="object-cover w-full h-full transition-all rounded-lg hover:opacity-80"
                />
              </div>
              <div className="absolute bottom-0 left-0 z-50 w-full p-5 font-medium text-white bg-black rounded-lg bg-opacity-95">
                {item.title}
              </div>
            </div>
          ))}
        </div>
        <div className="mt-10 mb-5 text-left">
          <div className="w-10 h-1 my-2 primary line"></div>
          <h3 className="text-2xl font-bold uppercase">About Us</h3>
        </div>
        {/* about us */}
        <div className="grid grid-cols-3 gap-5">
          <div
            className="border  w-full h-[350px] bg-center bg-cover bg-no-repeat relative bg-opacity-70  rounded-lg"
            style={{
              backgroundImage: `url("https://img.freepik.com/free-vector/cute-lion-walking-with-cheerful-cartoon-vector-icon-illustration-animal-nature-icon-isolated_138676-4866.jpg?w=740&t=st=1679405730~exp=1679406330~hmac=b50e947bc68d6d615bad0bf097cfdd29e5cbf4bec63ee198f17842321e831bfd")`,
            }}
          >
            <div className="absolute inset-0 bg-black rounded-lg -z-0 bg-opacity-70"></div>
            <div className="absolute bottom-0 left-0 z-10 w-full p-5 text-left text-white">
              <h3 className="mb-4 text-3xl font-bold">“ I'm a GOD ”</h3>
              <p className="mb-2 font-semibold">Do Phat Dat</p>
              <div className="flex items-center justify-between">
                <p>Owner of Canary</p>
                <Link
                  to="https://www.facebook.com/profile.php?id=100010598710045"
                  className="text-xs underline text-slate-300"
                  target="_blank"
                >
                  Contact me
                </Link>
              </div>
            </div>
          </div>
          <div
            className="border  w-full h-[350px] bg-center bg-cover bg-no-repeat relative bg-opacity-70  rounded-lg "
            style={{
              backgroundImage: `url("https://img.freepik.com/free-vector/cute-shiba-inu-dog-wearing-dino-costume-cartoon-vector-icon-illustration-animal-holiday-isolated_138676-7108.jpg?size=338&ext=jpg&uid=R40653510&ga=GA1.1.12167484.1678342596&semt=ais")`,
            }}
          >
            <div className="absolute inset-0 transition-all bg-black rounded-lg -z-0 bg-opacity-70 hover:bg-opacity-50"></div>
            <div className="absolute bottom-0 left-0 z-10 w-full p-5 text-left text-white">
              <h3 className="mb-4 text-3xl font-bold">“ I'm a GOD ”</h3>
              <p className="mb-2 font-semibold">Tran Ngoc Hung</p>
              <div className="flex items-center justify-between">
                <p>Owner of Canary</p>
                <Link
                  to="https://www.facebook.com/profile.php?id=100006405904709"
                  className="text-xs underline text-slate-300"
                  target="_blank"
                >
                  Contact me
                </Link>
              </div>
            </div>
          </div>
          <div
            className="border  w-full h-[350px] bg-center bg-cover bg-no-repeat relative bg-opacity-70  rounded-lg"
            style={{
              backgroundImage: `url("https://img.freepik.com/free-vector/cute-panda-with-bamboo-bag-cartoon-vector-icon-illustration-animal-education-icon-concept-isolated_138676-5818.jpg?size=338&ext=jpg&uid=R40653510&ga=GA1.1.12167484.1678342596&semt=ais")`,
            }}
          >
            <div className="absolute inset-0 bg-black rounded-lg -z-0 bg-opacity-70"></div>
            <div className="absolute bottom-0 left-0 z-10 w-full p-5 text-left text-white">
              <h3 className="mb-4 text-3xl font-bold">“ I'm a GOD ”</h3>
              <p className="mb-2 font-semibold">Nguyen Hoang Nhat Giang</p>
              <div className="flex items-center justify-between">
                <p>Owner of Canary</p>
                <Link
                  to="https://www.facebook.com/profile.php?id=100013185541028"
                  className="text-xs underline text-slate-300"
                  target="_blank"
                >
                  Contact me
                </Link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default HeaderTitle;
