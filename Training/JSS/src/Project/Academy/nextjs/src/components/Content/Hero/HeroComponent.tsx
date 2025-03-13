import {Text,Field,Link,withDatasourceCheck,RichText,ImageField, LinkField,}


from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';


type HeroComponentProps = ComponentProps & {
  fields: {
    bannerTitle: Field<string>;
    bannerText: Field<string>;
    bannerLink: LinkField;
    bannerBackgroundImage: ImageField;
  };
  params: {
    buttonStyleClass?: string;
    hideTitle?: string;
  }
};

const HeroComponent = (props: HeroComponentProps): JSX.Element => {

  const bannerBackgroundImage = props.fields.bannerBackgroundImage?.value?.src || '';
  const buttonStyleClass = props.params.buttonStyleClass || 'button-default';
  const hideTitle = props.params.hideTitle === '1';

  const backgroundImageStyle = {
    backgroundImage: `url(${bannerBackgroundImage})`,
    backgroundSize: 'cover',
    backgroundPosition: 'center',
    backgroundRepeat: 'no-repeat',
    width: '1920px',
    height: '800px'
  };


  return (
    <div style={backgroundImageStyle}>
      <div>
        <Text 
          tag="h1"
          field={props.fields.bannerTitle}
        />
        <RichText
          field={props.fields.bannerText}
        />
        <Link
          field={props.fields.bannerLink}>
          {props.fields.bannerLink.value.href}
        </Link>
      </div>
    </div>
  );
};

export default withDatasourceCheck()<HeroComponentProps>(HeroComponent);