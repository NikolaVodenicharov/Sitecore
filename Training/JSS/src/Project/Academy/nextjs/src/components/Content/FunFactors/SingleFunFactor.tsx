import React from 'react';
import {
  Field,
  ImageField,
  LinkField,
  Placeholder,
  RichText,
  Text,
  withDatasourceCheck,
} from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type SingleFunFactorProps = ComponentProps & {
  fields: {
    funFactorNumber: Field<string>;
    funFactorTitle: Field<string>;
  };
};

// const SingleFunFactor = ({fields}: SingleFunFactorProps): JSX.Element => {

//   return (
//     <div className="single-fun-factor mb-30">
//       <Text tag="h2" field={fields.funFactorNumber} />
//       <Text tag="h4" field={fields.funFactorTitle} />
//     </div>
//   )
// };

const SingleFunFactor = ({ fields }: SingleFunFactorProps): JSX.Element => {
  return (
    <div className="single-fun-factor mb-30">
      <h2>
        <Text field={fields.funFactorNumber} />
      </h2>
      <h4>
        <Text tag="h4" field={fields.funFactorTitle} />
      </h4>
      <style jsx>{`
        .single-fun-factor {
          text-align: center;
          padding: 40px 20px;
          border: 1px solid rgba(255, 255, 255, 0.2);
          background: rgba(0, 0, 0, 0.7);
          transition: all 0.3s ease-in-out;
          position: relative;
          z-index: 1;
        }
        .single-fun-factor:hover {
          border-color: #FFAE27;
        }
        .single-fun-factor h2 {
          font-size: 56px;
          line-height: 1.2;
          font-weight: 900;
          color: #FFAE27;
          margin: 10px 0;
        }
        .single-fun-factor h4 {
          font-size: 24px;
          line-height: 1.4;
          margin-top: 20px;
          font-weight: 500;
          color: #fff;
        }
      `}</style>
    </div>
  );
};


export default withDatasourceCheck()<SingleFunFactorProps>(SingleFunFactor);