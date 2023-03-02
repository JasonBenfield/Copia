import { GridView } from '@jasonbenfield/sharedwebapp/Views/Grid';
import { TextHeading1View } from '@jasonbenfield/sharedwebapp/Views/TextHeadings';
import { CopiaPageView } from '../CopiaPageView';
import { CopiaTheme } from '../CopiaTheme';

export class MainPageView extends CopiaPageView {

    constructor() {                                                     
        super();
        const grid = this.addView(GridView);
        grid.layout();
        grid.height100();
        const content = CopiaTheme.instance.mainContent(grid.addCell());
        content.addView(TextHeading1View).setText('Portfolio');
    }
}