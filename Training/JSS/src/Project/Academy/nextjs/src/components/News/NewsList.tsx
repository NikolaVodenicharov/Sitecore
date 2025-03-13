import React from 'react';
import { Image, Text, RichText, Link } from '@sitecore-jss/sitecore-jss-react';
import { Field, ImageField, withDatasourceCheck, ComponentParams } from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type NewsItem = {
  fields: {
    newsDate: Field<string>;
    newsViews: Field<string>;
    newsComments: Field<string>;
    newsTitle: Field<string>;
    newsDescription: Field<string>;
    newsImage: ImageField;
    linkUrl: Field<string>;
    linkName: Field<string>;
  }
}

type NewsListProps = ComponentProps & {
  fields: {
    newsListTitle: Field<string>;
    newsListDescription: Field<string>;
    news: NewsItem[];
  };
};

const NewsList = ({ fields }: NewsListProps): JSX.Element => {
  const { news: newsItems } = fields;

  const formatTime = (isoString: string, locales: Intl.LocalesArgument, options: Intl.DateTimeFormatOptions): string => {
    const date = new Date(isoString);
    return date.toLocaleTimeString(locales, options);
  };

  const getShortDate = (isoString: string): string => {
    const date = new Date(isoString);
    return date.toLocaleTimeString("en-GB",
      { day: "numeric", month: "short" }).split(",")[0];
  };

  const getTime = (isoString: string): string => {
    const date = new Date(isoString);
    return date.toLocaleTimeString("en-US",
      { hour: "numeric", minute: "2-digit", hour12: true })
  };

  const renderNews = (newsItemsArray?: NewsItem[]): JSX.Element | null => {
    if (!newsItemsArray || newsItemsArray.length === 0) {
      return <p>No news items available.</p>; // 👈 Prevents errors
    }

    return (
      <div className='row'>
        {
          newsItemsArray.map((item) =>
            <div className="col-lg-4 col-md-6 col-12">
              <div className="single-latest-item">
                <div className="single-latest-image">
                  <a href={item.fields.linkUrl.value}>
                    <img src={item.fields.newsImage.value?.src} alt=""/>
                  </a>
                </div>
                <div className="single-latest-text">
                  <h3>
                    <a href={item.fields.linkUrl.value}>{item.fields.newsTitle.value}</a>
                  </h3>
                  <div className="single-item-comment-view">
                    <span>
                      <i className="zmdi zmdi-calendar-check"></i>{getShortDate(item.fields.newsDate.value)}
                    </span>
                    <span>
                      <i className="zmdi zmdi-eye"></i> {item.fields.newsViews.value}
                    </span>
                    <span>
                      <i className="zmdi zmdi-comments"></i> {item.fields.newsComments.value}
                    </span>
                  </div>                  
                    <RichText field={item.fields.newsDescription}/>
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
                <h3>
                  <Text field={fields.newsListTitle} />
                </h3>
                <p>
                  <RichText field={fields.newsListDescription} />
                </p>
              </div>

              {renderNews(newsItems)}
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default withDatasourceCheck()<NewsListProps>(NewsList);


