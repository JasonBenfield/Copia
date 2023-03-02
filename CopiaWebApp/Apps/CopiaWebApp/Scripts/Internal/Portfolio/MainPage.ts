import { SingleActivePanel } from '@jasonbenfield/sharedwebapp/Panel/SingleActivePanel';
import { CopiaPage } from '../CopiaPage';
import { MainPageView } from './MainPageView';

class MainPage extends CopiaPage {
    constructor(protected readonly view: MainPageView) {
        super(view);
    }
}
new MainPage(new MainPageView());