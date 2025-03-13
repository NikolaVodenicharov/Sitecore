import { CommonFieldTypes, SitecoreIcon, Manifest } from '@sitecore-jss/sitecore-jss-dev-tools';

/**
 * Adds the TestimonialComponent component to the disconnected manifest.
 * This function is invoked by convention (*.sitecore.ts) when 'jss manifest' is run.
 * @param {Manifest} manifest Manifest instance to add components to
 */
export default function TestimonialComponent(manifest: Manifest): void {
  manifest.addComponent({
    name: 'TestimonialComponent',
    icon: SitecoreIcon.DocumentTag,
    fields: [{ name: 'heading', type: CommonFieldTypes.SingleLineText },
    { name: 'content', type: CommonFieldTypes.RichText },
    { name: 'author', type: CommonFieldTypes.SingleLineText },
    { name: 'image', type: 'image' },
    ],
 
  });
}