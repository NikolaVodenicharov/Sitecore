import {
  Field,
  withDatasourceCheck,
  ImageField,
  Image,
  RichText,
} from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type TestimonialProps = ComponentProps & {
  fields: {
    testimonialAuthor?: ImageField;
    testimonialText?: Field<string>;
    testimonialBackgroundImage?: ImageField;
  };
};

const Testimonial = ({ fields }: TestimonialProps): JSX.Element => (
  <div
    style={{
      backgroundImage: `url(${fields.testimonialBackgroundImage?.value?.src}`,
    }}
  >
    <div>
      <Image width={100} height={100} field={fields.testimonialAuthor?.value} />
    </div>
    <div>
      <RichText field={fields?.testimonialText} />
    </div>
  </div>
);

export default withDatasourceCheck()<TestimonialProps>(Testimonial);












// import { Text, withDatasourceCheck, RichText, ImageField, Field } from '@sitecore-jss/sitecore-jss-nextjs';
// import { ComponentProps } from 'lib/component-props';

// type TestimonialComponentProps = ComponentProps & {
//   fields: {
//     heading: Field<string>;
//     content: Field<string>;
//     author: Field<string>;
//     testimonialBackgroundImage: ImageField; 
//   };
// };

// const TestimonialComponent = ({ fields }: TestimonialComponentProps): JSX.Element => {
//   return (
//     <div>
//       <div>
//         {fields.image?.value && (
//           <img 
//             src={fields.image.value.src}
//             alt={typeof fields.image.value.alt === 'string' ? fields.image.value.alt : 'Testimonial image'}
//           />
//         )}
//       </div>
//       <div>
//         <div>
//           <RichText field={fields.content} />
//         </div>
//         <div>
//           <Text field={fields.author} />
//         </div>
//       </div>
//     </div>
//   );
// };

// export default withDatasourceCheck()<TestimonialComponentProps>(TestimonialComponent);