/** @type {import('next').NextConfig} */

const API_URL = process.env.NEXT_PUBLIC_API_URL || "/";

const nextConfig = {
  reactStrictMode: true,
  async rewrites() {
    return [
      {
        source: "/api/:path",
        destination: `${API_URL}/:path`,
      },
      {
        source: "/api/users/:path",
        destination: `${API_URL}/users/:path`,
      },
      {
        source: "/api/items/:path",
        destination: `${API_URL}/items/:path`,
      },
    ];
  },
}

module.exports = nextConfig