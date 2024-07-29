import { useQuery, useQueryClient } from "@tanstack/react-query"
import supabase from "../supabaseClient";

export const useRiders = () => {
    const queryClient = useQueryClient();

    const queryFn = async () => {
        let { data, error } = await supabase
            .from("riders")
            .select("*")
        return data;
    }

    const query = useQuery({
        queryKey: ["riders"],
        queryFn: queryFn
    });

    return query;
}