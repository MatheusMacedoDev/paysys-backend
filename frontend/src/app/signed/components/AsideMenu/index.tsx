import BalanceView from './BalanceView';
import UserView from './UserView';
import { Navigator } from './Navigator';

import {
    faCircleInfo,
    faHouse,
    faRocket
} from '@fortawesome/free-solid-svg-icons';

export default function AsideMenu() {
    return (
        <aside className="bg-gray-900 w-80 h-screen hidden lg:block fixed shadow-xl rounded-tr-xl rounded-br-xl p-10">
            <UserView />
            <BalanceView />

            <Navigator.Container>
                <Navigator.Section sectionTitle="Início" sectionIcon={faRocket}>
                    <Navigator.Item
                        itemHref="/"
                        itemTitle="Casa"
                        itemIcon={faHouse}
                    />
                    <Navigator.Item
                        itemHref="/"
                        itemTitle="Sobre"
                        itemIcon={faCircleInfo}
                    />
                </Navigator.Section>
            </Navigator.Container>
        </aside>
    );
}
