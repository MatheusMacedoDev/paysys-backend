import type { Metadata } from 'next';
import { Raleway } from 'next/font/google';
import './globals.css';

const raleway = Raleway({
    subsets: ['latin'],
    display: 'swap',
    variable: '--font-raleway'
});

export const metadata: Metadata = {
    title: 'Create Next App',
    description: 'Generated by create next app'
};

export default function RootLayout({
    children
}: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <html lang="pt-BR">
            <body className={raleway.className}>{children}</body>
        </html>
    );
}