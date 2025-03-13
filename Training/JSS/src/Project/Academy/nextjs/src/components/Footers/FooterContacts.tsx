import React from 'react';
import { Image, Text, RichText, Link } from '@sitecore-jss/sitecore-jss-react';
import { Field, ImageField, withDatasourceCheck, ComponentParams } from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type FooterContactsProps = ComponentProps & {
  fields: {
    contactsTitle: Field<string>;
    contactsPhoneNumber: Field<string>;
    contactsEmail: Field<string>;
    contactsWebSite: Field<string>;
    contactAddress: Field<string>;
  };
};

const FooterContacts = ({fields}: FooterContactsProps): JSX.Element =>{

  return (
    <div className="single-footer-widget">
      <Text tag="h3" field={fields.contactsTitle} />
    <a href="">
        <i className="fa fa-phone"></i><Text field={fields.contactsPhoneNumber} />
    </a>
    <span>
        <i className="fa fa-envelope"></i><Text field={fields.contactsEmail} />
    </span>
    <span>
        <i className="fa fa-globe"></i><Text field={fields.contactsWebSite} />
    </span>
    <span>
        <i className="fa fa-map-marker"></i><Text field={fields.contactAddress} />
    </span>
</div>
  )
}

export default withDatasourceCheck()<FooterContactsProps>(FooterContacts);


