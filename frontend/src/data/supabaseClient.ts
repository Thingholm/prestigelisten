import { createClient } from "@supabase/supabase-js";

const supabaseUrl = "https://ijyqomzpcigbnwjjohrd.supabase.co";
const supabaseKey = process.env.NEXT_PUBLIC_SUPABASE_KEY;

if (!supabaseKey){
    throw new Error("Missing NEXT_PUBLIC_SUPABASE_KEY env");
}

const supabase = createClient(supabaseUrl, supabaseKey);

export default supabase;