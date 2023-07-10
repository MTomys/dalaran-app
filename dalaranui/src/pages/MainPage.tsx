import React from 'react';
import { Link } from 'react-router-dom';

export const MainPage: React.FC = () => {
  return (
    <div>
      <h1 className="text-xl text-green-500 text-center mt-6">
        Welcome to the <span className="italic">dalaran&nbsp;</span>web forum
      </h1>
      <div className="mx-auto max-w-fit">
        <Link to="/login" className="text-green-500 mx-auto">
          login
        </Link>
      </div>
      <div className="mx-auto max-w-fit">
        <Link to="/register" className="text-green-500 mx-auto">
          request account
        </Link>
      </div>
      <div className="mx-auto max-w-fit">
        <Link to="/tour" className="text-green-500 mx-auto">
          take a tour
        </Link>
      </div>
    </div>
  );
};
