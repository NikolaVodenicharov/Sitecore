import React from 'react';
import { Image, Text, RichText, Link } from '@sitecore-jss/sitecore-jss-react';
import { Field, ImageField, withDatasourceCheck, ComponentParams } from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type EventItem = {
  fields: {
    eventInfoTitle: Field<string>;
    eventInfoDescription: Field<string>;
    eventInfoImage: ImageField;
    eventWhereaboutsStartDate: Field<string>;
    eventWhereaboutsEndDate: Field<string>;
    eventWhereaboutsLocation: Field<string>;
    linkUrl: Field<string>;
    linkName: Field<string>;
  }
}

type EventListProps = ComponentProps & {
  fields: {
    eventListTitle: Field<string>;
    eventListDescription: Field<string>;
    events: EventItem[];
  };
};

const EventList = ({fields}: EventListProps): JSX.Element =>{
  const { events } = fields;

  const formatTime = (isoString: string, locales: Intl.LocalesArgument, options: Intl.DateTimeFormatOptions): string => {
    const date = new Date(isoString);
    return date.toLocaleTimeString(locales, options);
  };

  const getShortDate = (isoString: string): string => {
    const date = new Date(isoString);
    return date.toLocaleTimeString("en-GB", 
                        { day: "numeric", month: "short"}).split(",")[0];
  };

  const getTime = (isoString: string): string => {
    const date = new Date(isoString);
    return date.toLocaleTimeString("en-US",
                        { hour: "numeric", minute: "2-digit", hour12: true })
  };

  const renderEvents = (eventItems: EventItem[]): JSX.Element => {
    return (
      <div className='row'>
        {
          eventItems.map((item) =>
            <div className="col-lg-4 col-md-6">
              <div className="single-event-item event-style-2">
                <div className="single-event-image">
                  <a href={item.fields.linkUrl.value}>
                    <img src={item.fields.eventInfoImage.value?.src} alt=""/>
                    <span>{getShortDate(item.fields.eventWhereaboutsStartDate.value)}</span>
                  </a>
                </div>
                <div className="single-event-text">
                  <h3><a href={item.fields.linkUrl.value}>{item.fields.eventInfoTitle.value}</a></h3>
                  <div className="single-item-comment-view">
                    <span>
                      <i className="zmdi zmdi-time">
                        {getTime(item.fields.eventWhereaboutsStartDate.value)} - {getTime(item.fields.eventWhereaboutsEndDate.value)}
                      </i>
                    </span>
                    <span>
                      <i className="zmdi zmdi-pin">
                        {item.fields.eventWhereaboutsLocation.value}
                      </i>
                    </span>
                  </div>

                      <RichText field={item.fields.eventInfoDescription}/>

                  <a className="button-default" href={item.fields.linkUrl.value}>{item.fields.linkName.value}</a>
                </div>
              </div>
            </div>
          )
        }
      </div>
    );
  }

  return (
    <div className="event-area section-padding bg-white event-page">
      <div className="container">
        <div className="row">
          <div className="col-md-12">
            <div className="section-title-wrapper">

              <div className="section-title">

                  <Text tag="h3"field={fields.eventListTitle} />

                  <RichText field={fields.eventListDescription} />

              </div>

              {renderEvents(events)}
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default withDatasourceCheck()<EventListProps>(EventList);


