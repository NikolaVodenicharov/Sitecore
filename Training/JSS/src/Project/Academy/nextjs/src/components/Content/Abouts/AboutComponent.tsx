// import { ImageField, Field, RichText } from '@sitecore-jss/sitecore-jss-nextjs';
// import { ComponentProps } from 'lib/component-props';

// type CtaLink = {
//   value: {
//     href: string;
//     text: string;
//     target?: string;
//   };
// };

// type AboutComponentProps = ComponentProps & {
//   fields: {
//     aboutTitle: Field<string>;
//     aboutText: Field<string>;
//     additionalDescription: Field<string>;
//     aboutImage: ImageField;
//     aboutLink: CtaLink;
//   };
// };


import React from 'react';
import { Image, Text, RichText, Link } from '@sitecore-jss/sitecore-jss-react';
import { Field, ImageField, ComponentParams } from '@sitecore-jss/sitecore-jss-nextjs';

interface CtaLink {
  value: {
    href: string;
    text: string;
    target?: string;
  };
}

interface AboutComponentProps {
  params: ComponentParams;
  fields: {
    aboutTitle: Field<string>;
    aboutText: Field<string>;
    aboutImage: ImageField;
    aboutLink: CtaLink;
    isImageLeftSide: Field<boolean>;
  };
}

const AboutComponent: React.FC<AboutComponentProps> = ({ fields }) => {
  if (!fields) {
    return <div>Loading...</div>;
  }

  const isImageLeft = fields.isImageLeftSide?.value;
  const textColumnClass = isImageLeft ? 'col-lg-7 order-lg-2' : 'col-lg-7 order-lg-1';
  const imageColumnClass = isImageLeft ? 'col-lg-5 order-lg-1' : 'col-lg-5 order-lg-2';

  return (
    <div className="about-area mt-95">
      <div className="container">
        <div className="row">
          {/* Image Section */}
          <div className={imageColumnClass}>
            <div className="about-image-area img-full">
              <Image field={fields.aboutImage} />
            </div>
          </div>

          {/* Text Section */}
          <div className={textColumnClass}>
            <div className="about-container">
              <h3 className="editable-text">
                <Text field={fields.aboutTitle} />
              </h3>
              <div className="editable-text">
                <RichText field={fields.aboutText} />
              </div>
              <div>
                <Link field={fields.aboutLink} className="button-default" />
              </div>
            </div>
          </div>
        </div>
      </div>

      <style jsx>{`
        @media (min-width: 768px) and (max-width: 991px) {
          .about-area.mt-95 {
            margin-top: 55px;
          }
          .container {
            max-width: 750px;
          }
          .about-container {
            margin-bottom: 30px;
          }
        }

        .container {
          padding-right: 0.9rem;
          padding-left: 0.9rem;
        }

        .row {
          display: flex;
          flex-wrap: wrap;
          margin-right: -0.75rem;
          margin-left: -0.75rem;
        }

        .row > * {
          padding-right: 0.75rem;
          padding-left: 0.75rem;
        }

        .img-full img {
          width: 100%;
        }

        .about-area .button-default {
          padding: 16px 27px;
          font-weight: 600;
          margin-top: 21px;
          border-radius: 50px;
          } 

        .button-default {
          background: #1F3971 none repeat scroll 0 0;
          color: #ffffff;
          display: inline-block;
          font-size: 14px;
          margin: 0;
          padding: 15px 35px;
          text-transform: uppercase;
          font-family: 'Montserrat', sans-serif;
          -webkit-transition: all 0.3s ease-in-out;
          transition: all 0.3s ease-in-out;
      `}</style>
    </div>
  );
};




// const AboutComponent = ({ fields }: AboutComponentProps): JSX.Element => {
//   return (
//     <section>
//       <div>
//         <div>
//           <div>
//             <h3>
//               <RichText
//               field={fields.aboutTitle}
//               />
//             </h3>
//             <RichText 
//             tag="p" 
//             field={fields.aboutText}
//             />
//    {/*          <RichText
//             tag="p"
//             field={fields.additionalDescription}
//             />
//             <a
//               href={fields.ctaLink?.value?.href || '#'}
//               target={fields.ctaLink?.value?.target || '_self'}
//             >
//               <button>
//                 {fields.ctaLink?.value?.text || 'Click here'}
//               </button>
//             </a>
//           </div>
//           <div>
//             {fields.image?.value && (
//               <img
//                 src={fields.image.value.src}
//                 alt="About image"
//               />
//             )} */}
//           </div>
//         </div>
//       </div>
//     </section>
//   );
// };

export default AboutComponent;


