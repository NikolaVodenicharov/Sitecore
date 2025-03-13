// eslint-disable-next-line no-unused-vars
import { Manifest } from '@sitecore-jss/sitecore-jss-dev-tools';

/**
 * Adds the AboutComponent component to the disconnected manifest.
 * This function is invoked by convention (*.sitecore.ts) when 'jss manifest' is run.
 * @param {Manifest} manifest Manifest instance to add components to
 */
export default function AboutComponent(manifest: Manifest): void {
  manifest.addComponent({
    name: 'AboutComponent',
    displayName: 'About Component',
    fields: [
      { name: 'heading', type: 'rich-text' },
      { name: 'description', type: 'rich-text' },
      { name: 'ctaLink', type: 'general-link' },
      { name: 'image', type: 'image' },
    ],
  })
}
