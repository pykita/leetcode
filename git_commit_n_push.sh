cd "$(dirname "${BASH_SOURCE[0]}")"
MESSAGE=${1:-}

git add --all && git commit -m "$MESSAGE" && git push