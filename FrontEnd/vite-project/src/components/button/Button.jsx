import React from "react";
import { Link } from "react-router-dom";

const Button = ({ children, className, links = "#", onClick }) => {
  return (
    <Link
      className={`${className} px-6 py-3 text-sm font-medium  rounded-lg  text-opacity-1 `}
      to={links}
    >
      {children}
    </Link>
  );
};

export default Button;
