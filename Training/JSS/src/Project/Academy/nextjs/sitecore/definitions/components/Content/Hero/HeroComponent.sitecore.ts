// eslint-disable-next-line no-unused-vars
import { CommonFieldTypes, SitecoreIcon, Manifest } from '@sitecore-jss/sitecore-jss-dev-tools';

/**
 
Adds the HeroComponent component to the disconnected manifest.
This function is invoked by convention (*.sitecore.ts) when 'jss manifest' is run.
@param {Manifest} manifest Manifest instance to add components to*/
export default function HeroComponent(manifest: Manifest): void {
  manifest.addComponent({
    name: 'HeroComponent',
    icon: SitecoreIcon.DocumentTag,
    fields: [
      { name: 'heading', type: CommonFieldTypes.SingleLineText },
      { name: 'description', type: CommonFieldTypes.RichText },
      { name: 'ctaLink', type: CommonFieldTypes.GeneralLink },
      { name: 'backgroundImage', type: CommonFieldTypes.Image },
    ],

    /*
    If the component implementation uses <Placeholder> or withPlaceholder to expose a placeholder,
    register it here, or components added to that placeholder will not be returned by Sitecore:
    placeholders: ['exposed-placeholder-name']
    */
  });
}