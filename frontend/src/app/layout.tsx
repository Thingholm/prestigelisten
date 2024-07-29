import type { Metadata } from "next";
import ReactQueryWrapper from "./ReactQueryWrapper";

export const metadata: Metadata = {
  title: "Create Next App",
  description: "Generated by create next app",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="dk">
      <body>
        <ReactQueryWrapper>
          {children}
        </ReactQueryWrapper>
        </body>
    </html>
  );
}
