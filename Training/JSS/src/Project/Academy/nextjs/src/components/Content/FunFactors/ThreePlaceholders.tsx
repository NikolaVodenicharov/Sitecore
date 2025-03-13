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

type ThreePlaceholdersProps = ComponentProps & {

}

// const ThreePlaceholders = ({ rendering}: ThreePlaceholdersProps): JSX.Element => {
//   return (
//     <div className="fun-factor-area">
//       <div className="container">
//         <div className="row">
//           <div className="col-lg-4 col-md-6 col-12">
//             <Placeholder name="jss-base-content-1"
//               rendering={rendering}
//               renderEach={(component, index) => <div key={index}>{component}</div>}
//               renderEmpty={(components) => <div>{components}</div>}
//             />
//           </div>
//           <div className="col-lg-4 col-md-6 col-12">
//             <Placeholder name="jss-base-content-2"
//               rendering={rendering}
//               renderEach={(component, index) => <div key={index}>{component}</div>}
//               renderEmpty={(components) => <div>{components}</div>}
//             />
//           </div>
//           <div className="col-lg-4 col-md-6 col-12">
//             <Placeholder name="jss-base-content-3"
//               rendering={rendering}
//               renderEach={(component, index) => <div key={index}>{component}</div>}
//               renderEmpty={(components) => <div>{components}</div>}
//             />
//           </div>
//         </div>
//       </div>
//     </div>
//     )
// };

const ThreePlaceholders = ({ rendering }: ThreePlaceholdersProps): JSX.Element => {
  return (
    <div className="fun-factor-area fun-bg-img">
      <div className="container">
        <div className="row">
          <div className="col-lg-4 col-md-6 col-12 single-fun-factor">
            <Placeholder name="jss-base-content-1"
              rendering={rendering}
            />
          </div>
          <div className="col-lg-4 col-md-6 col-12 single-fun-factor">
            <Placeholder name="jss-base-content-2"
              rendering={rendering}
            />
          </div>
          <div className="col-lg-4 col-md-6 col-12 single-fun-factor">
            <Placeholder name="jss-base-content-3"
              rendering={rendering}
            />
          </div>
        </div>
      </div>

      <style jsx>{`
        .fun-factor-area {
          background-size: cover;
          background-position: top;
          background-repeat: no-repeat;
          position: relative;
          padding-top: 100px;
          padding-bottom: 70px;
        }
        .fun-factor-area:before {
          position: absolute;
          content: "";
          top: 0;
          left: 0;
          width: 100%;
          height: 100%;
          background-color: rgba(0, 0, 0, 0.3);
          pointer-events: none; /* Ensure interactions work */
        }
        .single-fun-factor {
          text-align: center;
          padding: 40px 20px;
          border: 1px solid rgba(255, 255, 255, 0.2);
          background: rgba(0, 0, 0, 0.7);
          transition: all 0.3s ease-in-out;
          position: relative; /* Ensure it is above pseudo-element */
          z-index: 1; /* Make sure placeholders are interactable */
        }
        .single-fun-factor:hover {
          border-color: #FFAE27;
        }
      `}</style>
    </div>
  );
};

export default ThreePlaceholders;

//export default withDatasourceCheck()<ThreePlaceholdersProps>(ThreePlaceholders);