// @ts-check
import { defineConfig } from 'astro/config';
import tailwindcss from "@tailwindcss/vite";

import icon from 'astro-icon';

// https://astro.build/config
export default defineConfig({
    base: process.env.PUBLIC_BASE ?? '/',

    server: {
        port: 3000,
    },

    vite: {
        plugins: [tailwindcss()],
    },

    integrations: [icon({
        include: {
            tabler: ['download', 'brand-github', 'heart'],
        }
    })],
});