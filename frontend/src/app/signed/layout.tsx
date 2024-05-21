'use client';

import { ReactNode, useState } from 'react';
import CommonUserAsideMenu from './components/CommonUserAsideMenu';
import ShopkeeperAsideMenu from './components/ShopkeeperAsideMenu';
import AdministratorAsideMenu from './components/AdministratorAsideMenu';
import MobileHeader from './components/MobileHeader';

interface SignedLayoutProps {
    children: ReactNode;
}

export default function SignedLayout({ children }: SignedLayoutProps) {
    // eslint-disable-next-line @typescript-eslint/no-unused-vars
    const [userType, setUserType] = useState<
        'Common' | 'Shopkeeper' | 'Administrator'
    >('Administrator');

    return (
        <div className="w-screen min-h-screen">
            <MobileHeader />
            <div className="flex">
                {userType === 'Common' && <CommonUserAsideMenu />}
                {userType === 'Shopkeeper' && <ShopkeeperAsideMenu />}
                {userType === 'Administrator' && <AdministratorAsideMenu />}

                <main className="w-full overflow-scroll">{children}</main>
            </div>
        </div>
    );
}
